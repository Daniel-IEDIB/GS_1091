using System.Collections.Generic;
using Game;
using UnityEngine;

public class Plate : MonoBehaviour {

    private readonly HashSet<string> _carrots = new HashSet<string>();
   

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Zanahoria") && !_carrots.Contains(collider.gameObject.name)) {
            Debug.Log(collider.gameObject.name);
            _carrots.Add(collider.gameObject.name);
            GameStats.Carrots++;
        }
    }
}