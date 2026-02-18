using UnityEngine;

namespace Camera {
    public class CameraController : MonoBehaviour {
        [SerializeField] private Transform[] Povs;
        [SerializeField] private float Speed = 100;

        private int _index = 1;
        private Vector3 _target;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) _index = 0;
            else if (Input.GetKeyDown(KeyCode.Alpha2)) _index = 1;
            else if (Input.GetKeyDown(KeyCode.Alpha3)) _index = 2;
            else if (Input.GetKeyDown(KeyCode.Alpha4)) _index = 3;
            else if (Input.GetKeyDown(KeyCode.Alpha0)) _index = 4;
        
            _target = Povs[_index].position;
        }

        private void FixedUpdate() {
            transform.position = Vector3.MoveTowards(transform.position, _target, Speed * Time.deltaTime * Speed);
            transform.forward = Povs[_index].forward;
        }
    }
}
