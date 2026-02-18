using UnityEngine;
using UnityEngine.UI;

namespace Game {
    public class GameOverScreen : MonoBehaviour {

        public Text scoreText;

        public void DisplayScreen() {
            GameStats.IsGameOverScreenActive = true;
            gameObject.SetActive(true);
            SetScore();
        }

        private void SetScore() {
            string record = "";
            if (GameStats.IsRecord()) {
                GameStats.SetRecord();
            record = "NEW RECORD! ";
            }
            scoreText.text = record + GameStats.Points + " Points";
        }
    }
}