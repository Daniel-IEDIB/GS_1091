using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game {
    public class RestartGameButton : MonoBehaviour {
        public void Restart() {
            GameStats.RestartGame();
        }
    }
}