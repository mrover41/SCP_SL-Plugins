using Mirror;
using UnityEngine;

namespace Instinct.Core.Features;

public class PrefabStore<TPrefab> {
    private static TPrefab[]? _collection;
    private static TPrefab? _savedPrefab;
    
    public static TPrefab Prefab {
        get {
            if (_savedPrefab != null)
                return _savedPrefab;

            if (typeof(TPrefab) == typeof(ReferenceHub))
                return _savedPrefab = NetworkManager.singleton.playerPrefab.GetComponent<TPrefab>();

            return _savedPrefab = AllComponentPrefabs.FirstOrDefault()!;
        }
    }

    public static TPrefab[] AllComponentPrefabs {
        get {
            if (_collection != null)
                return _collection;

            List<TPrefab> allPrefabs = [];

            foreach (GameObject gameObject in NetworkClient.prefabs.Values) {
                if (gameObject.TryGetComponent(out TPrefab prefab))
                    allPrefabs.Add(prefab);
            }

            _collection = allPrefabs.ToArray();
            return _collection;
        }
    }
}
