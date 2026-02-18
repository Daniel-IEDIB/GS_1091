using UnityEngine;

namespace Monster {
    public class EnemyMovement : MonoBehaviour {
        
        public Transform Target;
        public float Speed = 3f; 

        void Update() {
            Vector3 direction = (Target.position - transform.position).normalized;
            transform.position += direction * Speed * Time.deltaTime;
            
            transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
        }
    }
}
