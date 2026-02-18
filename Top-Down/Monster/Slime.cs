using Shared;

namespace Monster {
    public class Slime : EnemyBase {
        private void Awake() {
            Initialize(null, 50, 10, 3f);
            "Slime creado".LogLevel(Console.Level.Info);
        }

        protected override void HandleDeath() {
           "Slime destruido".LogLevel(Console.Level.Death);
        }
    }
}