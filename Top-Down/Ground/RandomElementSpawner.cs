using UnityEngine;

namespace Ground {
    public class RandomElementSpawner : MonoBehaviour {

        public Transform Terrain;
        
        public GameObject[] Elements;
        private const int NumberOfElements = 500;

        private void Start() {
            SpawnElements();
        }
        
        private void SpawnElements() {
            for (int i = 0; i < NumberOfElements; i++) {
                GameObject element = Elements[Random.Range(0, Elements.Length)];
                Vector3 randomPosition = TerrainLimits.GetRandomPosition();
                
                Instantiate(element, randomPosition, Quaternion.identity, Terrain);
            }
        }
    }
}
