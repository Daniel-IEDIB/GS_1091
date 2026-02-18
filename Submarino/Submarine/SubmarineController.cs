using Game;
using Items;
using UnityEngine;

namespace Submarine {
    public class SubmarineController : MonoBehaviour {
        private Rigidbody2D _submarine;
        private SubmarineInputs _inputs;
        private float _emergeForce = 100f;
        private float _emergeCoeficient = 1.5f;

        private void Start() {
            _submarine = GetComponent<Rigidbody2D>();
            _inputs = GetComponent<SubmarineInputs>();
        }
        
        private void FixedUpdate() {
            if(Game.GameStats.GameOver) return;
            if (_inputs.Emerge > 0) {
                Emerge();
            } else  {
                Submerge();
            }
        }

        private void Emerge() {
            _emergeCoeficient *= 1.05f;
            float impulse = _emergeForce * _emergeCoeficient;
            _submarine.AddForce(impulse * new Vector2(0, 1), ForceMode2D.Impulse);
        }

        private void Submerge() {
            _emergeCoeficient = 1;
            _submarine.AddForce(-1.25f * _emergeForce * new Vector2(0, 1), ForceMode2D.Impulse);
        }
        
        private void OnCollisionEnter2D(Collision2D collision) {
            var collidedObject = collision.gameObject;

            if (collidedObject.TryGetComponent(out Coin coin)) {
                GameStats.Points += coin.Points;
                Debug.Log("Puntos: " + GameStats.Points);
            } else if (collidedObject.TryGetComponent(out Mine mine)) {
                GameStats.EndGame();
                _submarine.gravityScale = 0;
            }
        }
        
    }
}