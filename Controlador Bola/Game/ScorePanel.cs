using UnityEngine;
using UnityEngine.UI;

namespace Game {
    public class ScorePanel : MonoBehaviour {
        
        private int _playerScore = 0;
        private int _enemyScore = 0;

        public Text PlayerScore;
        public Text EnemyScore;

        private void FixedUpdate() {
            if(!PlayerScore || !EnemyScore) return;
            if (_playerScore != GameStats.Score) {
                _playerScore = GameStats.Score;
                SetPlayerScore();
            }

            if (_enemyScore != GameStats.EnemyScore) {
                _enemyScore = GameStats.EnemyScore;
                SetEnemyScore();
            }
        }

        private void SetPlayerScore() {
            PlayerScore.text = "Player Score:  " + GameStats.Score;
        }

        private void SetEnemyScore() {
            EnemyScore.text = "Enemy Score: " + GameStats.EnemyScore;

        }
    }
}