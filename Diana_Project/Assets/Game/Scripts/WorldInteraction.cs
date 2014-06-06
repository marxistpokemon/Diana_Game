using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldInteraction : MonoBehaviour {
	
	public List<Item> contextItems;

	void OnTriggerEnter (Collider other) {
		if(other.CompareTag("Item")){
			if(contextItems.FindIndex(i => i == other.GetComponent<Item>()) < 0) {
				contextItems.Add(other.GetComponent<Item>());
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if(other.CompareTag("Item")){
			if(contextItems.FindIndex(i => i == other.GetComponent<Item>()) >= 0) {
				contextItems.Remove(other.GetComponent<Item>());
			}
		}
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			// OpenInteractionMenu();
		}
	}
}
