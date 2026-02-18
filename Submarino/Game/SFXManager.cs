using UnityEngine;

namespace Game {
    public class SFXManager : MonoBehaviour {

        public static SFXManager Instance;
        public AudioSource SFXObject;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            }
        }

        public void PlaySFXClip(AudioClip clip, Transform parent) {
            AudioSource audioSource = Instantiate(SFXObject, parent.position, Quaternion.identity);
            audioSource.clip = clip;
            audioSource.Play();
            Destroy(audioSource.gameObject, clip.length);
        }
    }
}