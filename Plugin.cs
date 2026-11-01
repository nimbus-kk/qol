using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace nim_qol
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("KoboldKare.exe")]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;
        internal static PluginMenu Menu;
        internal static GenesMenu Genes;
        internal static GameState GameState;
        private static Keybinds Keybinds;

        private void Awake()
        {
            Logger = base.Logger;
            GameState = new GameState();
            Keybinds = new Keybinds(Config);
            Menu = new PluginMenu();
            Genes = new GenesMenu();

            new Harmony(MyPluginInfo.PLUGIN_GUID).PatchAll();

            GameObject bootstrap = new("PluginPhotonBootstrap");
            DontDestroyOnLoad(bootstrap);
            bootstrap.AddComponent<PhotonBootstrap>();
        }

        private void Update()
        {
            if (Keybinds.ToggleMenu.Value.IsDown()) Menu.Toggle();
        }

        private void OnGUI()
        {
            Menu.Draw();
            Genes.Draw();
        }
    }
}
