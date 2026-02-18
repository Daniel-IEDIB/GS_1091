using Ground;
using Items;
using Shared;
using UnityEngine;

namespace Player {
    public class PlayerController : MonoBehaviour {
        private Rigidbody _player;
        private PlayerInputs _inputs;
        private float _angle = 0f;
        
        private void Start() {
            _player = GetComponent<Rigidbody>();
            _inputs = GetComponent<PlayerInputs>();
        }

        private void FixedUpdate() {
            if (Player.IsDead) return;
            if (_inputs.AttackInput) {

            }
            if (_inputs.MoveInput != Vector2.zero) {
                Move();
            } else {
                SetRotation();
            }
        }

        private void Move() {
            _angle = Mathf.Atan2(_inputs.MoveInput.x, _inputs.MoveInput.y) * Mathf.Rad2Deg;
            SetRotation();
            MoveForward(_inputs.MoveInput.sqrMagnitude);
        }

        private void SetRotation() {
            _player.rotation = Quaternion.Euler(0, _angle, 0);
        }

        private void MoveForward(float magnitude) {
            _player.transform.Translate(Vector3.forward * (magnitude * Time.deltaTime * Player.Speed));
        }
        
        private void OnCollisionEnter(Collision collision) {
            if (Player.IsDead) return;
            
            var collidedObject = collision.gameObject;

            if (!collidedObject.TryGetComponent(out EnemyBase enemy)) return;
            
            Player.OnHit(enemy);
            "Colisionado con un enemigo!".LogLevel(Console.Level.Interaction);
            
            Destroy(collidedObject);
        }

        private void OnTriggerEnter(Collider trigger) {
            var triggerObject = trigger.gameObject;
            print(triggerObject);
            if (trigger.TryGetComponent<EnemyBase>(out EnemyBase enemy)) {
                enemy.TakeDamage(50);
            }

            if (!triggerObject.TryGetComponent(out HealingItemBase healingItem)) return;
            if (Mathf.Approximately(Player.Health, 100f)) {
                "No se puede usar un item de salud con la salud completa!".LogLevel(Console.Level.Interaction);
                return;
            }
            Player.UseHealingItem(healingItem);
            "Item de recuperación recogido!".LogLevel(Console.Level.Interaction);
            
            Destroy(triggerObject);
        }
    }
}
