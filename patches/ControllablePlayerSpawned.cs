using System.Collections;
using HarmonyLib;
using Photon.Pun;

namespace nim_qol
{
    [HarmonyPatch(typeof(NetworkManager), "SpawnControllablePlayerRoutine")]
    internal static class ControllablePlayerSpawned
    {
        private static void Postfix(ref IEnumerator __result)
        {
            __result = Wrapper(__result);
        }

        public static IEnumerator Wrapper(IEnumerator original)
        {
            while (original.MoveNext())
            {
                yield return original.Current;
            }

            Plugin.GameState.SetKobold((Kobold)PhotonNetwork.LocalPlayer.TagObject);
        }
    }
}