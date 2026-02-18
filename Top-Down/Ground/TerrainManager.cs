using UnityEngine;

namespace Ground {
    public class TerrainManager : MonoBehaviour {
        [SerializeField] private Vector2 TerrainSize = new Vector2(150f, 150f);
        [SerializeField] private Transform TerrainCenter;

        private void Awake() {
            TerrainLimits.Initialize(TerrainCenter.position, TerrainSize);
        }

        private void OnDrawGizmos() {
            if (TerrainCenter != null) {
                TerrainLimits.Initialize(TerrainCenter.position, TerrainSize);
                TerrainLimits.DrawGizmos();
            }
        }
    }
}