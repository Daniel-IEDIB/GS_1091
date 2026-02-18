using UnityEngine;

namespace Submarine {
    public class SubmarineBoundary : MonoBehaviour {

        private void LateUpdate() {
            Vector2 clampedPosition = transform.position;
            
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -18.0f, 21.0f);
            
            transform.position = clampedPosition;
            
        }
        
    }
}



