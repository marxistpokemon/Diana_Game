using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31.MessageKit;

[System.Serializable]
public class Slot {
	
	public string name;
	public EEquipSlots pos;
	public Equipable item;
	public Transform root;

	public Slot(EEquipSlots pPos) {
		pos = pPos;
		name = pPos.ToString();
	}
}

public class Inventory : MonoBehaviour
{
	// equipment slots
	public Slot[] slots;
	public List<Portable> inventory;

	void Start () {

		slots = new Slot[3];
		slots[(int)EEquipSlots.Body] = new Slot(EEquipSlots.Body);
		slots[(int)EEquipSlots.RightHand] = new Slot(EEquipSlots.RightHand);
		slots[(int)EEquipSlots.LeftHand] = new Slot(EEquipSlots.LeftHand);
		foreach (var s in slots) {
			s.root = transform.FindChild(s.pos.ToString());
		}
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.E)) {
			Equipable.Equip("Torch", slots[(int)EEquipSlots.RightHand]);
		}
		if(Input.GetKeyDown(KeyCode.Q)) {
			Equipable.Equip("Axe", slots[(int)EEquipSlots.RightHand]);
		}

	}
}

