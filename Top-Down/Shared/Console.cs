using UnityEngine;

namespace Shared {
    public static class Console {

        public enum Level {
            Info,
            Interaction,
            Heal,
            Hit,
            Death
        }

        private static string ToHex(this Color color) {
            return $"#{ToByte(color.r):X2}{ToByte(color.g):X2}{ToByte(color.b):X2}";
        }

        private static byte ToByte(float f) {
            return (byte)(Mathf.Clamp01(f) * 255);
        }

        public static string Color(this string text, Color color) {
            string output;
            output = $"<color={ToHex(color)}>{text}</color>";
            return output;
        }

        public static void LogLevel(this string text, Level level) {
            switch (level) {
                case Level.Info:
                    Debug.Log(text.Color(UnityEngine.Color.yellow));
                    break;
                case Level.Interaction:
                    Debug.Log(text.Color(UnityEngine.Color.blue));
                    break;
                case Level.Heal:
                    Debug.Log(text.Color(UnityEngine.Color.green));
                    break;
                case Level.Hit:
                    Debug.Log(text.Color(UnityEngine.Color.red));
                    break;
                case Level.Death:
                    Debug.Log(text.Color(UnityEngine.Color.black));
                    break;
                default:
                    Debug.Log(text);
                    break;
            }
        }

        public static void HealLog(this string text) {
            Debug.Log(text.Color(UnityEngine.Color.green));
        }
        public static void DeathLog(this string text) {
            Debug.Log(text.Color(UnityEngine.Color.black));
        }
    }
}