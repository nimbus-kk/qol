using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace nim_qol
{
    [HarmonyPatch]
    internal static class ThrowStrength
    {
        public static float Force = 10f;
        public static float GetForce() => Force;

        static MethodBase TargetMethod()
        {
            var type = AccessTools.Inner(typeof(Grabber), "GrabInfo");
            return AccessTools.Method(type, "Activate");
        }

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var Getter = AccessTools.Method(typeof(ThrowStrength), nameof(GetForce));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldc_R4 && instruction.operand is float v && v == 10f)
                {
                    instruction.opcode = OpCodes.Call;
                    instruction.operand = Getter;
                }

                yield return instruction;
            }
        }
    }
}
