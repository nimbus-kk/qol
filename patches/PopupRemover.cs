using System.Collections.Generic;
using HarmonyLib;

namespace nim_qol;

[HarmonyPatch(typeof(ShowOnceUI), "OnEnable")]
internal static class PopupRemoverPatch
{
    private static readonly List<string> Popups = [
        "Canvas - 18Check",
        "Canvas - AlphaPopup",
    ];

    private static void Postfix(ShowOnceUI __instance)
    {
        if (Popups.Contains(__instance.name))
        {
            __instance.gameObject.SetActive(false);
            Plugin.Logger.LogInfo($"PopupRemoverPatch - Prevented '{__instance.name}' from showing.");
        }
    }
}
