using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCO.Patch
{
    internal class DamagePatch
    {
        [HarmonyPatch(typeof(PlayerControllerB), "DamagePlayer")]
        [HarmonyPrefix]
        private static void DamagePlayerPrefix(ref int damageNumber, CauseOfDeath causeOfDeath, bool fallDamage)
        {

            LCO.logger.LogInfo($"DamagePlayerPrefix: {damageNumber} : {causeOfDeath} : {fallDamage}");
            CauseOfDeath key = causeOfDeath;
            if (fallDamage)
            {
                key = CauseOfDeath.Gravity;
            }
            //damageNumber = (int)((float)damageNumber * Config.Instance.damageScaling[key]);


        }
    }
}
