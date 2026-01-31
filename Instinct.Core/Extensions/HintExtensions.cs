using Hints;
using HintServiceMeow.Core.Enum;
using HintServiceMeow.Core.Extension;
using HintServiceMeow.Core.Models.Hints;
using HintServiceMeow.Core.Utilities;
using MEC;
using UnityEngine;
using Hint = HintServiceMeow.Core.Models.Hints.Hint;

namespace Instinct.Core.Extensions;

public static class HintExtensions {
    private static readonly Dictionary<Player, Dictionary<AbstractHint, string>> TagsByPlayer = new();

    extension(Player? player) {
        public void ShowCoreHint(string message, float duration = 3f) {
            List<AbstractHint>? hints = player?.GetHintsByTag("center");
    
            if (hints != null) {
                int lineCount = message.Split('\n').Length + 1;
                float shift = lineCount * 27;

                foreach (AbstractHint? absHint in hints) {
                    if (absHint is Hint hint) {
                        hint.YCoordinate = Math.Max(0, hint.YCoordinate + shift);
                    }
                }
            }
            
            player.ShowHint(message, new Vector2(0.0f, 680.0f), duration, HintVerticalAlign.Middle, tag: "center");
        }

        public void ShowCoreHint(Hints.Hint hint) {
            if (hint is not TextHint textHint) return;

            player.ShowCoreHint(textHint.Text, hint.DurationScalar);
        }

        public Hint? ShowHint(string message, Vector2 position, float time = 3f, HintVerticalAlign verticalAlign = HintVerticalAlign.Top, HintAlignment alignmentHint = HintAlignment.Center, int fontSize = 27, string tag = "defaultTag") {
            if (player == null) {
                Logger.Debug("Player is null, cant send hint");
                return null;
            }
        
            PlayerDisplay playerDisplay = PlayerDisplay.Get(player);

            Hint hint = new() {
                Text = message,
                FontSize = fontSize,
                Alignment = alignmentHint,
                XCoordinate = position.x,
                YCoordinate = position.y,
                YCoordinateAlign = verticalAlign
            };

            playerDisplay.AddHint(hint);
            playerDisplay.RemoveAfter(hint, time);
        
            if (!TagsByPlayer.TryGetValue(player, out Dictionary<AbstractHint, string>? playerTags))
                TagsByPlayer[player] = playerTags = new Dictionary<AbstractHint, string>();

            playerTags[hint] = tag;
        
            Timing.CallDelayed(time, () => {
                if (TagsByPlayer.TryGetValue(player, out Dictionary<AbstractHint, string>? d)) {
                    d.Remove(hint);
                    if (d.Count == 0)
                        TagsByPlayer.Remove(player);
                }
            });

            return hint;
        }
    }

    extension(Player player) {
        public void ClearHints() {
            player.GetPlayerDisplay().ClearHint();
            TagsByPlayer.Remove(player);
        }

        public void ClearHints(string tag) {
            if (!TagsByPlayer.TryGetValue(player, out Dictionary<AbstractHint, string>? dict))
                return;

            List<AbstractHint>? toRemove = player.GetHintsByTag(tag);
        
            PlayerDisplay.Get(player).RemoveHint(toRemove);

            if (toRemove != null)
                foreach (AbstractHint? hint in toRemove)
                    dict.Remove(hint);

            if (dict.Count == 0)
                TagsByPlayer.Remove(player);
        }

        public List<AbstractHint>? GetHintsByTag(string tag) {
            if (!TagsByPlayer.TryGetValue(player, out Dictionary<AbstractHint, string>? dict))
                return null;
            
            return dict.Where(x => x.Value == tag).Select(x => x.Key).ToList();
        }
    }
}