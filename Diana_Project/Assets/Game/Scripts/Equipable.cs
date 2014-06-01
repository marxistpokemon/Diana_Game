using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

[RequireComponent(typeof(Portable))]
public class Equipable : ItemProperty
{
	public bool equipped;
	public bool twoHanded;
	public bool isHandEquipment;
	
	public static bool Equip (string itemName, Slot slot) {
		if (Resources.Load<Equipable>("Items/" + itemName) == null) {
			return false;
		}
		MessageKit.post(MsgType.EquipedChanged);
		if(slot.item != null) { // there was an item before
			Equipable.Unequip(slot);
		}
		slot.item = Instantiate (Resources.Load<Equipable>("Items/" + itemName), slot.root.position, 
		                         Quaternion.identity) as Equipable;
		slot.item.equipped = true;
		slot.item.transform.parent = slot.root;
		return slot.item.equipped;
	}
	
	public static bool Unequip (Slot slot) {
		MessageKit.post(MsgType.EquipedChanged);
		Destroy(slot.item.gameObject);
		return true;
	}
}

