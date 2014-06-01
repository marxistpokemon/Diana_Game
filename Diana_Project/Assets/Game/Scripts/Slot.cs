using UnityEngine;
using System.Collections;

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

