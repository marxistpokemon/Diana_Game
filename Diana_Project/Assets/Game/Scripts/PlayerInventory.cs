using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31.MessageKit;



public class PlayerInventory : MonoBehaviour
{
	// equipment slots
	public List<Equipable> equipped;
	public List<Portable> inventory;

	void Start () {
		equipped = new List<Equipable>(3);
	}

	void Update () {
	}
}

