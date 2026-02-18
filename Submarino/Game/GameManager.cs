using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game {
    public class GameManager : MonoBehaviour {
        
        public GameOverScreen GameOverScreen;

        private void FixedUpdate() {
            if (!GameStats.GameOver) return;
            if (!GameStats.IsGameOverScreenActive) {
                EndGame();
            }
            
            if (GameStats.Restart) {
                RestartGame();
            }
        }

        private void EndGame() {
            BlueFilter.Instance.DisableScreen();
            GameOverScreen.DisplayScreen();
        }

        private void RestartGame() {
            GameStats.ResetStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}