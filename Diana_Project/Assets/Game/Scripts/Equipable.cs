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
		Portable tempP = Inventory.i.storage.Find(t => t.name == itemName );
		if(tempP == null) {
			Equipable tempE = Resources.Load<Equipable>("Items/" + itemName);
			if (tempE == null) {
				return false;
			}
		}
		Inventory.i.RemoveItem(itemName);
		MessageKit.post(MsgType.Equip);
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
		MessageKit.post(MsgType.Unequip);
		if(Inventory.i.AddItem(slot.item.name)){
			Destroy(slot.item.gameObject);
		}
		return true;
	}
}

