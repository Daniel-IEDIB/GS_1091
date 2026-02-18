using UnityEngine;

namespace Shared {
    public static class Spawner {
        
        private static float _spawnRadiusMin = 10f;
        private static float _spawnRadiusMax = 20f;
        
        public static Vector3 GetRandomSpawnPosition(Transform player) {
            Vector2 randomPoint = Random.insideUnitCircle.normalized * Random.Range(_spawnRadiusMin, _spawnRadiusMax);
            Vector3 spawnPosition = new Vector3(randomPoint.x, 0, randomPoint.y);
            return player.position + spawnPosition;
        }
    }
}