using PugMod;
using System.Collections.Generic;
using System.Globalization;
using Unity.Mathematics;
using UnityEngine;

namespace HealthBars.Scripts
{
    public static class Options
    {
        private static Vector3 _HealthBarOffset = new Vector3(0f, 0f, -0.75f);

        private const string DefaultColor = "#db412f";

        public static float Opacity { get; private set; }
        public static bool AlwaysShow { get; private set; }
        public static Color Color { get; private set; }

        public static bool ShowOnSelf { get; private set; }

        public static void Init()
        {
            Opacity = math.clamp(RegisterAndGet("Opacity", "Opacity of health bars.", 0.4f), 0.1f, 1f);
            AlwaysShow = RegisterAndGet("AlwaysShow", "If set to true, shows health bars at full health.", false);
            Color = ParseHexColor(RegisterAndGet("Color", "Color of health bars.", "#db412f")) ?? ParseHexColor(DefaultColor).Value;
            _HealthBarOffset = RegisterAndGet("HealthBarOffset", "Offset of health bars.", new Vector3(0f, 0f, -0.75f));
            ShowOnSelf = RegisterAndGet("ShowOnSelf", "If set to true, shows health bars on the local player.", false);
        }

        private static T RegisterAndGet<T>(string key, string description, T defaultValue = default)
        {
            return API.Config.Register(Main.InternalName, "Config", description, key, defaultValue).Value;
        }

        public static Vector3 GetHealthBarOffset()
        {
            return _HealthBarOffset;
        }

        private static Color? ParseHexColor(string hexColor)
        {
            if (string.IsNullOrEmpty(hexColor) || hexColor.Length < 7)
                return null;

            hexColor = hexColor.Replace("#", "");

            return new Color(
                byte.Parse(hexColor.Substring(0, 2), NumberStyles.HexNumber) / 255f,
                byte.Parse(hexColor.Substring(2, 2), NumberStyles.HexNumber) / 255f,
                byte.Parse(hexColor.Substring(4, 2), NumberStyles.HexNumber) / 255f,
                1f
            );
        }
    }
}