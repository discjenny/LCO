using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using LCO.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCO.Patch
{
    [HarmonyPatch]
    internal class HealthPatch
    {
        [HarmonyPatch(typeof(StartOfRound), "Start")]
        [HarmonyPostfix]
        private static void SetHealthPostfix(PlayerControllerB __instance)
        {
            __instance.health = LCO.employee.hitpoints;
            LCO.logger.LogInfo("setting player hitpoints");
        }
    }
}
