using System;
using UnityEngine;

namespace Player {
    public class CameraController : MonoBehaviour {
        [SerializeField] private Transform Target;
        private readonly Vector3 _offset = new Vector3(0, 15, 0);
        private readonly float _smoothSpeed = 1f;
        private void FixedUpdate() {
            if (!Target) return;
            Vector3 desiredPosition = Target.position + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(Target);
        }
    }
}
