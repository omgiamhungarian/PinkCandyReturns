using PluginAPI.Enums;
using PluginAPI.Events;
using PluginAPI.Core.Attributes;
using HarmonyLib;
using InventorySystem.Items.Usables.Scp330;
using PluginAPI.Core;

namespace PinkCandyReturns
{
    public class PinkCandyReturns
    {
        public static PinkCandyReturns Singleton;

        [PluginConfig]
        public Config Config;

        [PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint("PinkCandyReturns", "1.0.0", "The funny pink candy returns.", "omgiamhungarian")]

        public void LoadPlugin()
        {
            if (!Config.IsEnabled)
            {
                return;
            }

            Singleton = this;
            EventManager.RegisterEvents(this);

            Harmony harmony = new Harmony("omgiamhungarian.PinkCandyReturns");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(CandyPink), "SpawnChanceWeight", MethodType.Getter)]
        public class PinkCandyPatch
        {
            public static void Postfix(ref float __result)
            {
                float candyWeight = Singleton.Config.CandyWeight;
                __result = candyWeight;
            }
        }
    }
}