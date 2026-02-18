using UnityEngine;

namespace Ground {
    public static class TerrainLimits {
        public static Vector2 TerrainSize { get; private set; }
        private static Vector3 _terrainCenter = Vector3.zero;
        public static float MinX { get; private set; }
        public static float MaxX { get; private set; }
        public static float MinZ { get; private set; }
        public static float MaxZ { get; private set; }

        public static void Initialize(Vector3 terrainCenter, Vector2 terrainSize) {
            _terrainCenter = terrainCenter;
            TerrainSize = terrainSize;
            
            MinX = _terrainCenter.x - TerrainSize.x / 2f;
            MaxX = _terrainCenter.x + TerrainSize.x / 2f;
            MinZ = _terrainCenter.z - TerrainSize.y / 2f;
            MaxZ = _terrainCenter.z + TerrainSize.y / 2f;
        }

        public static Vector3 GetRandomPosition() {
            Vector3 terrainMin = _terrainCenter - new Vector3(TerrainSize.x / 2f, 0, TerrainSize.y / 2f);
            Vector3 terrainMax = _terrainCenter + new Vector3(TerrainSize.x / 2f, 0, TerrainSize.y / 2f);

            float randomX = Random.Range(terrainMin.x, terrainMax.x);
            float randomZ = Random.Range(terrainMin.z, terrainMax.z);
            return new Vector3(randomX, _terrainCenter.y + 1, randomZ);
        }

        public static void DrawGizmos() {
            Vector3 size = new Vector3(TerrainSize.x, 0.1f, TerrainSize.y);
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_terrainCenter, size);
        }
    }
}