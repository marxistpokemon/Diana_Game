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
	public List<Equipment> equipped;
	public List<IPortable> inventory;

	void Start () {
		MessageKit.addObserver(MsgType.EquipedChanged, OnEquippedChanged);
		// initial equipment, for testing
		equipped = new List<Equipment>(3);
		equipped.Insert((int)EquipmentSlots.Body, new Equipment("Light clothes"));
		equipped.Insert((int)EquipmentSlots.RightHand, new Equipment("Torch"));

		//inventory.Add(new Equipment("Sword"));
	}

	void Update () {
		DebugUtil.i.guiText.text = equipped[0].name + ",\n" + equipped[1].name;
		if(Input.GetKeyDown(KeyCode.Alpha0)){
			(inventory[0] as Equipment).Equip();
		}
	}

	void OnEquippedChanged() {
		print ("equipment");
	}
}

