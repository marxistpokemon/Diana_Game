using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public interface IEquipable {
	bool Equip ();
	bool Unequip ();
}

[System.Serializable]
public class Item {
	public static int itemCount;

	public string name;
	public int id;

	public Item (string pName) {
		name = pName;
		Item.itemCount++;
		id = itemCount;
	}
}

[System.Serializable]
public class Equipment : Item, IEquipable {

	public bool equiped;
	public bool twoHanded;
	public bool isHandEquipment;

	public Equipment (string pNameEquip) : base (pNameEquip) {
		equiped = false;
	}

	public bool Equip () {
		MessageKit.post(MsgType.EquipedChanged);
		equiped = true;
		return equiped;
	}

	public bool Unequip () {
		MessageKit.post(MsgType.EquipedChanged);
		equiped = false;
		return equiped;
	}
}



