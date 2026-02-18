using Game;
using UnityEngine;

namespace Enemy {
    public class EnemySpawner : MonoBehaviour {
        public GameObject[] EnemyPrefabs;
        public Transform Target;
        public Transform Player;

        public void SpawnEnemy() {
            if (EnemyPrefabs.Length <= 0 || !Target || !Player) return;
            for (int i = 0; i < GameStats.Round; i++) {

                Vector3 spawnPosition = new Vector3(Random.Range(-10, -3.8f), 0, Random.Range(-5, 5));

                GameObject randomEnemy = EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];

                GameObject spawnedEnemy = Instantiate(randomEnemy, spawnPosition, Quaternion.identity);

                Enemy enemy = spawnedEnemy.GetComponent<Enemy>();
                if (enemy != null) {
                    enemy.Initialize(Target, Player, enemy.Speed, enemy.Strength);
                }
            }
        }
    }
}