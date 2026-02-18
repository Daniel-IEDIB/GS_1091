using Items;
using Shared;
using UnityEngine;
using Console = Shared.Console;

namespace Player {
    public static class Player {
        public static float Speed = 10f;
        public static int Strength = 1000;
        public static int Health {
            get => _health;
            set => _health = Mathf.Clamp(value, 0, _maxHealth);
        }
        private static int _health = 100;
        private static int _maxHealth = 100;
        public static bool IsDead = false;

        private static void _printHP() {
            // Shared.Console.ClearLog();
            Debug.Log($"Salud: {Health}".Color(Color.green));
        }

        public static void UseHealingItem(HealingItemBase healingItem) {
            Health += healingItem.HealingPoints;
            $"Salud recuperada + {healingItem.HealingPoints} HP".LogLevel(Console.Level.Heal);
            _printHP();
        }

        public static void OnHit(EnemyBase enemy) {
            Health -= enemy.Strength;
            $"Salud perdida - {enemy.Strength}".LogLevel(Console.Level.Hit);
            _printHP();
            enemy.TakeDamage(Strength);
            if (Health > 0) return;
            Die();
        }

        private static void Die() {
            IsDead = true;
            "El jugador ha muerto.".LogLevel(Console.Level.Death);
        }
        
    }
}