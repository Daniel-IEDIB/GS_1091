using Game;
using UnityEngine;

namespace Player {
    public class PlayerController : MonoBehaviour {
        private Rigidbody _player;
        public PlayerInputs _inputs;
        private float _angle = 0f;
        [SerializeField] private Transform _target;

        
        private void Start() {
            _player = GetComponent<Rigidbody>();
            _inputs = GetComponent<PlayerInputs>();
        }
        
        private void FixedUpdate() {
            if(!_player || !_inputs) return;
            if (GameStats.IsRoundsScreenActive) return;
            if (_inputs.MoveInput != Vector2.zero) {
                Move();
            }

            if (_inputs.ImpulseInput != 0 && Player.IsAutoLaunchActive) {
                if (!_target) return;

                Vector3 direction = (_target.position - transform.position).normalized;
                _player.AddForce(_inputs.ImpulseInput * direction * 5, ForceMode.Impulse);
            }

            if (IsOutOfBounds() && !GameStats.IsGoal) {
                RestartPlayerPosition();
            }
            
            _player.transform.localScale = new Vector3(Player.Scale.x, Player.Scale.y, Player.Scale.z);
            _player.mass = Player.Mass;
        }
        
        private void Move() {
            if (_inputs.MoveInput.x != 0) {
                _player.AddForce(Vector3.left * (_inputs.MoveInput.x * Player.Speed));
            }

            if (_inputs.MoveInput.y != 0) {
                _player.AddForce(Vector3.back * (_inputs.MoveInput.y * Player.Speed));
            }
        }

        private bool IsOutOfBounds() {
            return _player.position.y < -25;

        }

        public float GetPlayerStrength() {
            return Player.Strength * _player.linearVelocity.magnitude;
        }
        
        private void OnTriggerEnter(Collider trigger) {
            if (GameStats.IsGoal) return;
            var collider = trigger.GetComponent<Collider>();

            if (collider.CompareTag("Red2")) {
                GameStats.IsGoal = true;
                GameStats.Score += 1;
            }
            
            if (collider.CompareTag("Red1")) {
                GameStats.Score -= 1;
            }
        }

        public void RestartPlayerPosition() {
            _player.linearVelocity = Vector3.zero;
            transform.position = new Vector3(3.8f, 0, 0);
            GameStats.IsGoal = false;
        }
    }
}