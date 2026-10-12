
using UnityEngine;

namespace nim_qol
{
    internal sealed class PluginMenu
    {
        private bool IsOpen = false;
        private Rect WindowRect = new(20, 20, 256, 256);


        internal void Open()
        {
            if (Plugin.GameState.InGame && MainMenu.GetCurrentMode() == MainMenu.MainMenuMode.None)
                Cursor.lockState = CursorLockMode.None;

            IsOpen = true;
        }

        internal void Close()
        {
            if (Plugin.GameState.InGame && MainMenu.GetCurrentMode() == MainMenu.MainMenuMode.None)
                Cursor.lockState = CursorLockMode.Locked;

            IsOpen = false;
        }

        internal void Toggle()
        {
            if (IsOpen) Close();
            else Open();
        }

        internal void Draw()
        {
            if (IsOpen)
            {
                WindowRect = GUI.Window(-999, WindowRect, WindowFunction, "nim's QoL");
            }
        }

        internal void WindowFunction(int windowID)
        {
            GUI.Label(new Rect(0, 20, WindowRect.width, 20), $"InGame {Plugin.GameState.InGame}");
            GUI.Label(new Rect(0, 40, WindowRect.width, 20), $"CheatsEnabled {Plugin.GameState.CheatsEnabled}");
            GUI.Label(new Rect(0, 60, WindowRect.width, 20), $"IsHost {Plugin.GameState.IsHost}");

            GUI.DragWindow();
        }
    }
}