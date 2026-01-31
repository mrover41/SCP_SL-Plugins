using UnityEngine;

namespace Instinct.Core.Extensions;

public static class RandomExtensions {
    extension<T>(Dictionary<T, int> dic) {
        public T RandomWeight(T defaultVal = default!) {
            int sum = dic.Values.Sum();
            int chance = RandomGenerator.GetInt32(1, sum + 1);
            T returnT = defaultVal;
            foreach (KeyValuePair<T, int> kv in dic) {
                if (chance <= kv.Value)
                {
                    returnT = kv.Key;
                    break;
                }
                chance -= kv.Value;
            }
            return returnT;
        }

        public T RandomWeight(Func<KeyValuePair<T, int>, bool> predicate, T defaultVal = default!) {
            return dic.Where(predicate).ToDictionary(x => x.Key, x => x.Value).RandomWeight(defaultVal);
        }
    }

    public static Vector3 RandomVector3(float min, float max) {
        return new Vector3(RandomGenerator.GetFloat(min, max), RandomGenerator.GetFloat(min, max), RandomGenerator.GetFloat(min, max));
    }
}