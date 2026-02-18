using System.Collections;
using Enemy;
using UnityEngine;

namespace Game {
    public class GameManager : MonoBehaviour {
        
        public RoundsScreen RoundsScreen;
        public EnemySpawner EnemySpawner;
        private void FixedUpdate() {
            if (!RoundsScreen || !EnemySpawner) return;

            if (GameStats.IsRoundEnded()) {
                StartNewRound();
            }
            if (GameStats.IsPowerUpActive) {
                GameStats.IsPowerUpActive = false;
                StartCoroutine(Player.Player.ResetStats(5f));
            }
        }

        private void StartNewRound() {
            StartCoroutine(RestartPlayerPosition());
            StartCoroutine(HandleRoundsScreenDisplay());
            StartCoroutine(SpawnEnemy());
            GameStats.IsWaveActive = true;

        }

        private IEnumerator RestartPlayerPosition() {
            yield return new WaitForSeconds(3f);
            FindObjectOfType<Player.PlayerController>().RestartPlayerPosition();
        }
        
        private IEnumerator HandleRoundsScreenDisplay() {
            GameStats.Round++;
            RoundsScreen.DisplayScreen();
            yield return new WaitForSeconds(3f);
            RoundsScreen.HideScreen();

        }

        private IEnumerator SpawnEnemy() {
            yield return new WaitForSeconds(3.5f);
            EnemySpawner.SpawnEnemy();
        }
    }
}