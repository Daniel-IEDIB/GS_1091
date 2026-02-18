using System.Collections;
using UnityEngine;

public class Barrera : MonoBehaviour {

    private float _direction;
    bool _isOpened = false;

    private void Start() {
        _direction = gameObject.transform.rotation.y > 0 ? 1f : -1f;

    }
    void Update(){
        if (gameObject.activeInHierarchy && !_isOpened) {
            StartCoroutine(OpenGate());
            gameObject.transform.Rotate(Vector3.up * (_direction * 75 * Time.deltaTime));
        }
    }

    private IEnumerator OpenGate() {
        yield return new WaitForSeconds (2f);
        _isOpened = true;
    }
}