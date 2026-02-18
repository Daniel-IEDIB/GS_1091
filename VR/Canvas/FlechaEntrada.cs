using System;
using UnityEngine;

namespace Canvas {
    public class FlechaEntrada : MonoBehaviour {
        private readonly Vector3 _growthFactor = new Vector3(0.33f, 0.33f, 0.33f);
        private bool _isGrowing = true;

        private void Update() {
            if (!gameObject.activeInHierarchy) return;
            if (_isGrowing) {
                Upscale();
            }
            else {
                Downscale();
            }
        }

        private void Upscale() {
            transform.localScale = transform.localScale + _growthFactor * Time.deltaTime;
            if (gameObject.transform.localScale.x > 0.6f) _isGrowing = false;
        }

        private void Downscale() {
            transform.localScale = transform.localScale - _growthFactor * Time.deltaTime;
            if (gameObject.transform.localScale.x < 0.3f) _isGrowing = true;
        }

        /*private void OnTriggerEnter(Collider collider) {
            Debug.Log(collider.gameObject.name);
            if (collider.gameObject.tag == "Player") {
                Debug.Log("!!!!!");
            }
        }*/
    }
}
