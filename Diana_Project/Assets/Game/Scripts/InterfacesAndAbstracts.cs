using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#region Items

public interface ItemProperty {
}

public interface IPortable : ItemProperty {
	bool Load ();
	bool Unload ();
}

public interface IEquipable : ItemProperty {
	bool Equip ();
	bool Unequip ();
}

public abstract class Item {
	
	public static int itemCount;
	public string name;
	public int id;
	
	public Item (string pName) {
		name = pName;
		Item.itemCount++;
		id = itemCount;
	}
}

#endregion

#region Actions
public abstract class Verb {

	public string name;
	public List<string> reqs; 
	
	public Verb (string pName, string[] pReqs) {
		name = pName;
		reqs = new List<string>();
		foreach (var req in pReqs) {
			Type t = Type.GetType(req);
			if(t.GetInterface("ItemProperty") != null){
				reqs.Add(req);
				Debug.Log (req);
			}
		}
	}
}

public abstract class Target {
	public string name;
	public Target (string pName) {
		name = pName;
	}
}
#endregion
