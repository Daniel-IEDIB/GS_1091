using UnityEngine;

namespace PowerUps {
    public class PowerUpSpawner : MonoBehaviour {
        public GameObject[] PowerUpsPrefabs;
        private bool _isPowerUpInGame = false;

        private void Start() {
            InvokeRepeating("SpawnPowerUps", 10, 15);
        }

        private void SpawnPowerUps() {
            if (PowerUpsPrefabs.Length <= 0 || _isPowerUpInGame) return;
            GameObject randomItem = PowerUpsPrefabs[Random.Range(0, PowerUpsPrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-8, 7));
            
            GameObject spawned = Instantiate(randomItem, spawnPosition, Quaternion.identity);
            
            PowerUp powerUp = spawned.GetComponent<PowerUp>();
            if (powerUp != null) {
                powerUp.Initialize();
            }
            _isPowerUpInGame = true;

            spawned.GetComponent<PowerUp>().OnDestroy += () => RestartSpawner();
        }

        private void RestartSpawner() {
            _isPowerUpInGame = false;
        }
    }
}