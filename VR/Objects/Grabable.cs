using UnityEngine;

public class Grabable : MonoBehaviour {

    Rigidbody rb;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        if (rb.position.y > 0) {
            rb.isKinematic = false;
        }
    }
}
