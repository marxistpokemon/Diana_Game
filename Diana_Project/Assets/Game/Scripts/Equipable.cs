using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class Equipable : ItemProperty
{
	public bool equipped;
	public bool twoHanded;
	public bool isHandEquipment;
	
	void Start() {
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
}

