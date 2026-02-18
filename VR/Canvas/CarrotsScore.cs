using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Canvas {
    public class CarrotsScore : MonoBehaviour {

        private int _carrots = 0;
        public TextMeshProUGUI CarrotsScoreText;
        public TextMeshProUGUI WinText;

        private void FixedUpdate() {
            if (_carrots != GameStats.Carrots) {
                _carrots = GameStats.Carrots;
                
                CarrotsScoreText.text = _carrots.ToString() + "/5";
            }
            
            if (_carrots >= 5) {
                WinText.text = "¡OBJETIVO CUMPLIDO!";
            }
        }
    
    }
}