using Ground;
using UnityEngine;

namespace Player {
    public class PlayerBoundary : MonoBehaviour {
        private void LateUpdate() {
            Vector3 clampedPosition = transform.position;
            
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, TerrainLimits.MinX, TerrainLimits.MaxX);
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, TerrainLimits.MinZ, TerrainLimits.MaxZ);
            
            transform.position = clampedPosition;
        }
    }
}