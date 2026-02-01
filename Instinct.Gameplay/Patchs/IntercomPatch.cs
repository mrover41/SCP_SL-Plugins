using GameCore;
using HarmonyLib;
using PlayerRoles.Voice;
using UnityEngine;

namespace Instinct.Gameplay.Patchs {
    [HarmonyPatch(typeof(Intercom), nameof(Intercom.Update))]
    internal static class IntercomPatch {
        [HarmonyPrefix]
        // ReSharper disable once InconsistentNaming
        private static bool OnUpdate(Intercom __instance) {
            if (Round.IsRoundInProgress) return true;
            
            if (!IntercomDisplay.TrySetDisplay(
                    $"<size=200><color=#{HColor(0.5f)}> ◀✅▶ До начала раунда: {(RoundStart.singleton.NetworkTimer < 1 ? "Скоро начнется!" : RoundStart.singleton.NetworkTimer.ToString())}\n" +
                    $"Количество игроков: {Player.List.Count - 1} </color></size>")) {
                Logger.Error("тута ощьиибочкааа (интерком текст не поставил)");
            }
            
            return true;
        }

        private static string HColor(float speed, bool pingPong = false) {
            float t = Mathf.PingPong(Time.time * speed, 1f);

            Color startColor = Color.red;
            Color endColor = Color.blue;

            Color lerpedColor;
            if (pingPong) {
                lerpedColor = Color.Lerp(startColor, endColor, t); 
            } else {
                lerpedColor = HSVLerp(Time.time * speed);
            }

            return ColorUtility.ToHtmlStringRGB(lerpedColor);
        }

        private static Color HSVLerp(float t) {
            float hue = Mathf.Repeat(t, 1f); // 0..1
            return Color.HSVToRGB(hue, 1f, 1f);
        }
    }
}