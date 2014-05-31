using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31.MessageKit;

public enum EquipmentSlots {
	Body,
	RightHand,
	LeftHand
}

public class PlayerInventory : MonoBehaviour
{
	// equipment slots
	public List<Equipment> equipSlots;
	public List<Item> inventory;

	void Start () {
		MessageKit.addObserver(MsgType.EquipedChanged, OnEquipedChanged);
		// initial equipment, for testing
		equipSlots = new List<Equipment>(3);
		equipSlots.Insert((int)EquipmentSlots.Body, new Equipment("Light clothes"));
		equipSlots.Insert((int)EquipmentSlots.RightHand, new Equipment("Torch"));

		inventory.Add(new Equipment("Sword"));
	}

	void Update () {
		DebugUtil.i.guiText.text = equipSlots[0].name + ",\n" + equipSlots[1].name;
		if(Input.GetKeyDown(KeyCode.Alpha0)){
			(inventory[0] as Equipment).Equip();
		}
	}

	void OnEquipedChanged() {
		print ("equipment");
	}
}

