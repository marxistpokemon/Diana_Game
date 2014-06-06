using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31.MessageKit;

public class Inventory : MonoBehaviour
{
	public static Inventory i;
	public float capacity;
	public float currentWeight;
	// equipment slots
	public Slot[] slots;
	public List<Portable> storage;

	void Awake () {
		i = this;
	}

	void Start () {
		storage = new List<Portable>();
		slots = new Slot[3];
		slots[(int)EEquipSlots.Body] = new Slot(EEquipSlots.Body);
		slots[(int)EEquipSlots.RightHand] = new Slot(EEquipSlots.RightHand);
		slots[(int)EEquipSlots.LeftHand] = new Slot(EEquipSlots.LeftHand);
		foreach (var s in slots) {
			s.root = transform.FindChild(s.pos.ToString());
		}
		//Initial stuff
		AddItem("Torch");
		AddItem("Axe");
	}


	void Update () { // test values
		if(Input.GetKeyDown(KeyCode.E)) {
			if(slots[(int)EEquipSlots.RightHand].item != null){
				Equipable.Unequip(slots[(int)EEquipSlots.RightHand]);
			}
			else {
				Equipable.Equip(storage.Find(i => i.name == "Torch").name, slots[(int)EEquipSlots.RightHand]);
			}

		}
		if(Input.GetKeyDown(KeyCode.Q)) {
			if(slots[(int)EEquipSlots.RightHand].item != null){
				Equipable.Unequip(slots[(int)EEquipSlots.RightHand]);
			}
			else {
				Equipable.Equip(storage.Find(i => i.name == "Axe").name, slots[(int)EEquipSlots.RightHand]);
			}
		}
	}
	
	public bool AddItem (string itemName) {
		Portable temp = Resources.Load<Portable>("Items/" + itemName);
		if(temp == null){
			return false;
		}
		if(temp.weight + currentWeight > capacity) {
			return false;
		}
		currentWeight += temp.weight;
		storage.Add(temp);
		return true;
	}

	public bool RemoveItem (string itemName) {
		Portable temp = storage.Find(i => i.name == itemName);
		Debug.Log(temp);
		if(temp == null){
			return false;
		}
		currentWeight -= temp.weight;
		storage.Remove(temp);
		return true;
	}
}

