using UnityEngine;

namespace Items {
    public class Coin : ItemBase {

        public AudioClip Clip;
        public ParticleSystem Particles;
        
        private void Awake() {
            Vector3 torque = Vector2.down * 75f * Time.deltaTime;
            Initialize(11, 0, 10, torque, Clip, Particles);
        }
    }
}