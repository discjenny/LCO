﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LCO.Patch;
using LCO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace LCO
{
    [BepInPlugin(GUID, GUID, version)]
    public class LCO : BaseUnityPlugin
    {
        private const string GUID = "LCO";
        private const string version = "0.0.1";

        private Harmony harmony;

        public static ManualLogSource logger = new ManualLogSource(GUID);

        public static Employee employee;

        public static LCO Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            logger = base.Logger;

            logger.LogInfo("LCO is loading...");

            employee.Init();
            
            try
            {
                harmony = new(GUID);
                harmony.PatchAll(typeof(DamagePatch));
                harmony.PatchAll(typeof(HealthPatch));
                harmony.PatchAll(typeof(HPRegenPatch));
                //harmony.PatchAll(Assembly.GetExecutingAssembly());
                logger.LogInfo("Plugin loaded.");
            }
            catch (Exception e)
            {
                logger.LogError(e);
            }
            
        }
    }
}