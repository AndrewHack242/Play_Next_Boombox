using HarmonyLib;
using UnityEngine;

namespace Play_Next_Boombox.Patches
{
    [HarmonyPatch(typeof(BoomboxItem))]
    internal class Play_next_patch
    {

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void Patch_start(ref AudioSource ___boomboxAudio)
        {
            ___boomboxAudio.loop = false;
        }

        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        static void Patch_update(ref BoomboxItem __instance, ref AudioSource ___boomboxAudio, ref bool ___isPlayingMusic)
        {
            if (___isPlayingMusic && !___boomboxAudio.isPlaying)
            {
                __instance.ItemActivate(false);
                __instance.ItemActivate(true);
            }
        }

    }
}
