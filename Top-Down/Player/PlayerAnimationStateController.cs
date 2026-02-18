using UnityEngine;

namespace Player {
    public class PlayerAnimationStateController : MonoBehaviour {
        private Animator _animator;
        private PlayerInputs _inputs;


        private void Start() {
            _animator = GetComponent<Animator>();
            _inputs = GetComponent<PlayerInputs>();

        }
        
        private void Update() {
            _animator.SetBool("IsWalking", _inputs.MoveInput != Vector2.zero);
            if (_inputs.AttackInput) {
                _animator.SetTrigger("Attack");
            }
            
        }

        private void OnCollisionEnter(Collision collision) {
            EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
            if (enemy == null) return;
            _animator.SetTrigger("Hit");
            if (Player.IsDead) {
                _animator.SetBool("IsDead", true);
            }
        }
    }
}
