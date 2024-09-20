using PugMod;
using UnityEngine;

namespace HealthBars.Scripts {
    public class Main : IMod {
        public const string Version = "0.0.1";
        public const string InternalName = "PlayerHealthBars";

        internal static GameObject PlayerHealthBarPrefab { get; private set; }

        public void EarlyInit() {
            Debug.Log($"[{InternalName}]: Mod version: {Version}");
        }

        public void Init() {
            Options.Init();
        }

        public void Shutdown() { }

        public void ModObjectLoaded(Object obj) {
            if (obj.name == "PlayerHealthBar")
                PlayerHealthBarPrefab = (GameObject) obj;
        }

        public void Update() { }
    }
}
