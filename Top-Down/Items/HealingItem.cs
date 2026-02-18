using System;
using Shared;
using UnityEngine;
using Console = Shared.Console;

namespace Items {
    public class HealingItem : MonoBehaviour {
        public event Action OnHealItemDestroy;
        public float Lifetime = 30f;

        private void Start() {
            Invoke(nameof(DestroyHealItem), Lifetime);
        }

        private void DestroyHealItem() {
            OnHealItemDestroy?.Invoke();
            Destroy(gameObject);
            "El Item de salud ha desaparecido tras 30 segundos".LogLevel(Console.Level.Info);
        }
    }
}