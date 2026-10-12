using BepInEx.Configuration;
using UnityEngine;

namespace nim_qol
{
    internal sealed class Keybinds
    {
        internal readonly ConfigEntry<KeyboardShortcut> ToggleMenu;

        internal Keybinds(ConfigFile config)
        {
            ToggleMenu = config.Bind("Hotkeys", "Toggle Menu", new KeyboardShortcut(KeyCode.Insert), "Opens or closes the plugin menu.");
        }
    }
}