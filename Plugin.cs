using System;
using System.Text.RegularExpressions;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace nim_qol
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("KoboldKare.exe")]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;
        internal static PluginMenu Menu;
        internal static GameState GameState;
        private static Keybinds Keybinds;
        private static bool _callbacksRegistered;

        private void Awake()
        {
            Logger = base.Logger;
            Menu = new PluginMenu();
            GameState = new GameState();
            Keybinds = new Keybinds(Config);

            new Harmony(MyPluginInfo.PLUGIN_GUID).PatchAll();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Update()
        {
            if (Keybinds.ToggleMenu.Value.IsDown()) Menu.Toggle();
        }

        private void OnGUI()
        {
            Menu.Draw();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!_callbacksRegistered)
            {
                _callbacksRegistered = true;
                Logger.LogWarning("PhotonNetwork.AddCallbackTarget");
                PhotonNetwork.AddCallbackTarget(GameState);
            }

        }
    }
}
