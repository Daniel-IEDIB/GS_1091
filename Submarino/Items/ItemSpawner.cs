using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Items {
    public class ItemSpawner : MonoBehaviour {
        public GameObject[] ItemPrefabs;
        
        public int MaxItems;
        public int Time;
        private readonly List<GameObject> _activeItems = new List<GameObject>();


        private void Start() {
            InvokeRepeating("SpawnItem", Time, 2f);
        }

        private void SpawnItem() {
            
            if( _activeItems.Count >= MaxItems || Game.GameStats.GameOver) return;
            GameObject randomItem = ItemPrefabs[Random.Range(0, ItemPrefabs.Length)];
            Vector3 spawnPosition = new Vector2(60, Random.Range(-20, 20));
            GameObject spawnedItem = Instantiate(randomItem, spawnPosition, Quaternion.identity);
            spawnedItem.transform.localScale = new Vector3(10, 10, 10);
            
            ItemBase item = spawnedItem.GetComponent<ItemBase>();
            if (item != null) {
                item.Initialize(item.Speed, item.Damage, item.Points, item.Torque, item.Clip, item.Particles);
            }

            _activeItems.Add(spawnedItem);
            spawnedItem.GetComponent<ItemBase>().OnItemDestroy += () => RemoveItemFromList(spawnedItem);
        }

        private void RemoveItemFromList(GameObject item) {
            _activeItems.Remove(item);
        }
    }
}