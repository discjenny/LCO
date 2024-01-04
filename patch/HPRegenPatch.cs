using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace LCO
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class HPRegenPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("LateUpdate")]
        private static void HPRegenUpdate(PlayerControllerB __instance)
        {
            LCO.logger.LogInfo("late update");
            if (__instance.health >= 100)
                return;

            if (LCO.employee.hpRegenScale == 0)
                return;

            if (__instance.healthRegenerateTimer <= 0f)
            {
                LCO.logger.LogInfo("try regen");
                __instance.healthRegenerateTimer = 1f / LCO.employee.hpRegenScale;
                __instance.health++;

                if (__instance.health >= 20)
                {
                    __instance.MakeCriticallyInjured(false);
                }
                HUDManager.Instance.UpdateHealthUI(__instance.health, false);
            }
            else
            {
                __instance.healthRegenerateTimer -= Time.deltaTime;
            }
        }
    }
}