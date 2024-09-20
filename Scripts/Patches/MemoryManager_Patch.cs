using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace HealthBars.Scripts.Patches {
    [HarmonyPatch]
    public static class MemoryManager_Patch {
        [HarmonyPatch(typeof(MemoryManager), nameof(MemoryManager.Init))]
        [HarmonyPrefix]
        public static void InjectPoolablePrefabs(MemoryManager __instance) {
            if (__instance.poolablePrefabBanks == null)
                return;

            var prefabBank = ScriptableObject.CreateInstance<PooledGraphicalObjectBank>();

            prefabBank.poolablePlatformScaling = new List<PoolablePrefabBank.PlatformObjectPoolScaling>();
            prefabBank.poolInitializers = new List<PoolablePrefabBank.PoolablePrefab> {
                new PoolablePrefabBank.PoolablePrefab {
                    prefab = Main.PlayerHealthBarPrefab,
                    initialSize = 4,
                    maxSize = 128,
                    maxFreeSize = 128
                }
            };

            __instance.poolablePrefabBanks.Add(prefabBank);
        }
    }
}
