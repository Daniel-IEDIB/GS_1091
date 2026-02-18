using System.Collections;
using Game;
using Player;
using UnityEngine;

namespace Enemy {
    public abstract class Enemy : MonoBehaviour {
        private Rigidbody _self;
        public float Speed { get; private set; }
        public int Strength { get; private set; }
        private Transform _target;
        private Transform _player;
        private bool isHit = false;
    
        public void Initialize(Transform target, Transform player, float speed, int strength) {
            _self = GetComponent<Rigidbody>();
            _target = target;
            _player = player;
            Strength = strength;
            Speed = speed;
        }

        public void SetTarget(Transform target) {
            _target = target;
        }
        
        protected virtual void Update() {
            if (!isHit) MoveTowardsTarget();
        }
        
        private void MoveTowardsTarget() {
            if (_target == null) return;

            Vector3 direction = (_target.position - transform.position).normalized;
            transform.position += direction * Speed * Time.deltaTime;
            transform.LookAt(new Vector3(_target.position.x, transform.position.y, _target.position.z));
        }

        private void OnCollisionEnter(Collision collision) {
            var collidedObject = collision.gameObject;
            if (collidedObject.TryGetComponent(out PlayerController player)) {
                isHit = true;
                Deflect();
                StartCoroutine(DestroyEnemy(2f));
            }
        }
        
        private void OnTriggerEnter(Collider trigger) {
            var collider = trigger.GetComponent<Collider>();

            if (collider.CompareTag("Red2")) {
                GameStats.EnemyScore -= 1;
                StartCoroutine(DestroyEnemy(2f));
            }
            
            if (collider.CompareTag("Red1")) {
                GameStats.EnemyScore += 1;
                StartCoroutine(DestroyEnemy(2f));
            }
        }

        private void Deflect() {
            _player.TryGetComponent(out PlayerController player);
            _self.AddForce(_player.localEulerAngles * Time.fixedDeltaTime * player.GetPlayerStrength(), ForceMode.Impulse);
        }
        
        private IEnumerator DestroyEnemy(float time) {
            if (gameObject == null) yield break;
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
            if(FindObjectsOfType<Enemy>().Length == 1) {
                GameStats.IsWaveActive = false;
            }
        }
    
    }
}