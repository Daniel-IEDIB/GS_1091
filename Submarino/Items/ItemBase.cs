using System;
using Game;
using Submarine;
using UnityEngine;

namespace Items {
    public abstract class ItemBase : MonoBehaviour {
        public event Action OnItemDestroy;
        private const float LeftBound = -21f;

        
        public float Speed  {get; private set;}
        public int Damage {get; private set;}
        public int Points {get; private set;}
        
        public Vector3 Torque {get; private set;}
        
        public AudioClip Clip {get; private set;}
        public ParticleSystem Particles {get; private set;}
        private ParticleSystem _particlesInstance;

     
        public void Initialize(float speed, int damage, int points, Vector3 torque, AudioClip clip, ParticleSystem particles) {
            Speed = speed;
            Damage = damage;
            Points = points;
            Torque = torque;
            Clip = clip;
            Particles = particles;
        }
        
        private void Update() {
            if(Game.GameStats.GameOver) return;
            transform.position += Vector3.left * Speed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(Torque);

            if (transform.position.x < LeftBound) {
                DestroyItem();
            }
        }

        protected void DestroyItem() {
            OnItemDestroy?.Invoke();
            Destroy(gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D collision) {
            var collidedObject = collision.gameObject;
            if (collidedObject.TryGetComponent(out SubmarineController submarine)) {
                
                SFXManager.Instance.PlaySFXClip(Clip, transform);
                SpawnParticles();

                DestroyItem();
            }
        }
        
        private void SpawnParticles() {
            _particlesInstance = Instantiate(Particles, transform.position, Quaternion.identity);
        }
        
    }
}