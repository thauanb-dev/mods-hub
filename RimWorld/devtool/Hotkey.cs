using RimWorld;
using UnityEngine;
using Verse;

namespace thx0s_Hotkey
{
    [StaticConstructorOnStartup]
    internal static class Hotkey
    {
        private static Thing lastSelectedThing = null;
        private static bool inspectionMode = false;
        private static bool pendingFirstInspect = false;

        public static void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                inspectionMode = !inspectionMode;

                Messages.Clear();
                Messages.Message(
                    inspectionMode ? "Inspection ON" : "Inspection OFF",
                    MessageTypeDefOf.PositiveEvent
                );

                lastSelectedThing = null;
                pendingFirstInspect = inspectionMode;
            }

            if (!inspectionMode) return;

            RunInspectionMode();
        }

        private static void RunInspectionMode()
        {
            var selectedThing = Find.Selector.SingleSelectedThing;
            if (selectedThing == null) return;

            // só dispara se mudou o thing ou se acabou de ligar
            if (!pendingFirstInspect && selectedThing == lastSelectedThing)
                return;

            pendingFirstInspect = false;
            lastSelectedThing = selectedThing;

            Messages.Clear();

            string info =
                "======= Inspector Mode =======\n" +
                $"Name       : {selectedThing.LabelCap}\n" +
                $"DefName    : {selectedThing.def?.defName}\n" +
                $"Minifiable : {selectedThing.def?.Minifiable}\n" +
                "==============================";

            Messages.Message(info, MessageTypeDefOf.NeutralEvent);
            Log.Message($"[Inspector] def={selectedThing.def?.defName}");
        }
    }
}
