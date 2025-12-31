using HarmonyLib;
using Verse;

namespace thx0s_Hotkey
{
    [HarmonyPatch(typeof(Root_Play), nameof(Root_Play.Update))]
    public static class HotkeyPatch
    {
        static void Postfix()
        {
            Hotkey.Update();
        }
    }
}
