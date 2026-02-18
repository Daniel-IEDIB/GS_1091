using UnityEngine;

namespace Player {
    public class CameraController : MonoBehaviour {
        [SerializeField] private Transform Target;
        private readonly Vector3 _offset = new Vector3(0, 15, 20);
        private readonly float _smoothSpeed = 1f;

        private void Start() {
            transform.rotation = Quaternion.Euler(0,-45,0);
        }

        private void Update() {
            if (!Target) return;
            Vector3 desiredPosition = Target.position * -1 + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(Target);
        }
    }
}