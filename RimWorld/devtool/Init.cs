using Verse;
using HarmonyLib;

namespace thx0s_Init
{
    public class Init : Mod
    {
        public Init(ModContentPack content) : base(content)
        {

            Log.Message("Mod Iniciado 🔥");
            Harmony harmony = new Harmony("thx0s.testmod");
            harmony.PatchAll();
        }
    }
}
    