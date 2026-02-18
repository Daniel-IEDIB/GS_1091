using UnityEngine;

namespace Items {
    public class Mine : ItemBase{
        
        public AudioClip Clip;
        public ParticleSystem Particles;
        
        private void Awake() {
            Vector3 torque = Vector2.down * 75f * Time.deltaTime;
            Initialize(10, 10, 0, torque, Clip, Particles);
        }
    }
}