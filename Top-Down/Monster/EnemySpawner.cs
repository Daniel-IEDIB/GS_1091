using System.Collections.Generic;
using Shared;
using UnityEngine;

namespace Monster {
    public class EnemySpawner : MonoBehaviour {
        
        public GameObject[] EnemyPrefabs;
        public Transform Target;         
        
        public int MaxEnemies = 100;
        
        private readonly List<GameObject> _activeEnemies = new List<GameObject>();
        
        private void Start() {
            InvokeRepeating(nameof(SpawnEnemy), 1f, 2f);
        }

        private void SpawnEnemy() {
            if (Player.Player.IsDead || _activeEnemies.Count >= MaxEnemies) return;
            Vector3 spawnPosition = Spawner.GetRandomSpawnPosition(Target);
            
            GameObject randomEnemy = EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];
            
            GameObject spawnedEnemy = Instantiate(randomEnemy, spawnPosition, Quaternion.identity);
            
            EnemyBase enemy = spawnedEnemy.GetComponent<EnemyBase>();
            if (enemy != null) {
                enemy.Initialize(Target, enemy.Health, enemy.Strength, enemy.Speed);
            }
            _activeEnemies.Add(spawnedEnemy);
            spawnedEnemy.GetComponent<EnemyBase>().OnDeath += () => RemoveEnemyFromList(spawnedEnemy);
        }
        
        private void RemoveEnemyFromList(GameObject enemy) {
            _activeEnemies.Remove(enemy);
        }
    }
}
