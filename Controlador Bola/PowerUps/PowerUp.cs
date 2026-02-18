using System;
using System.Collections;
using Game;
using Player;
using UnityEngine;

namespace PowerUps {
    public abstract class PowerUp : MonoBehaviour {
        
        public event Action OnDestroy;

        public void Initialize() {}

        private void OnTriggerEnter(Collider trigger) {
            var collider = trigger.GetComponent<Collider>();
            if (!collider.TryGetComponent<PlayerController>(out var player)) return;
            Activate();
            DestroyPowerUp();
        }

        protected virtual void Activate() {}

        private void DestroyPowerUp() {
            OnDestroy?.Invoke();
            GameStats.IsPowerUpActive = true;
            Destroy(gameObject);
        }
    }
}