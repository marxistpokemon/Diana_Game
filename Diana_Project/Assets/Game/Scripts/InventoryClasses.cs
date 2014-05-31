using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

[System.Serializable]
public class Equipment : Item, IEquipable, IPortable {

	public bool equipped;
	public bool twoHanded;
	public bool isHandEquipment;

	public Equipment (string pName) : base (pName) {
		equipped = false;
	}

	public bool Equip () {
		MessageKit.post(MsgType.EquipedChanged);
		equipped = true;
		return equipped;
	}

	public bool Unequip () {
		MessageKit.post(MsgType.EquipedChanged);
		equipped = false;
		return equipped;
	}

	public bool Load(){
		// add to inventory
		return true;
	}

	public bool Unload(){
		// drop from inventory
		return true;
	}
}



