using Shared;
using UnityEngine;

namespace Monster {
    public class Turtle : EnemyBase {
        private void Awake() {
            Initialize(null, 200, 30, 1f);
            "Tortuga creada".LogLevel(Console.Level.Info);
        }
        
        protected override void HandleDeath() {
           "Tortuga destruida".LogLevel(Console.Level.Death);
        }
    }
}