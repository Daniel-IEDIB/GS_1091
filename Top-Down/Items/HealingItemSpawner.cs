using Ground;
using Shared;
using UnityEngine;

namespace Items {
    public class HealingItemSpawner : MonoBehaviour {
        public GameObject HealthItemPrefab;
        public Transform Target;   
        private void Start() {
            InvokeRepeating(nameof(SpawnHealthItem), 3f, 10f);
        }

        private void SpawnHealthItem() {
            if (Player.Player.IsDead) return;
            Vector3 randomPosition = Spawner.GetRandomSpawnPosition(Target);
            Instantiate(HealthItemPrefab, randomPosition, Quaternion.identity);
            "Item de recuperación creado".LogLevel(Console.Level.Info);
        }
    }
}