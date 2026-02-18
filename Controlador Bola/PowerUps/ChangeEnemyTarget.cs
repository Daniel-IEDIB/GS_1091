using UnityEngine;

namespace PowerUps {
    public class ChangeEnemyTarget : PowerUp{
        protected override void Activate() {
            var enemies = FindObjectsOfType<Enemy.Enemy>();
            foreach (var enemy in enemies) {
                enemy.SetTarget(GameObject.FindGameObjectWithTag("Red2").transform);
            }
        }
    }
}