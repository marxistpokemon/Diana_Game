using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ActionManager : MonoBehaviour
{
	[SerializeField]
	public List<Verb> verbs;
	public List<Verb> available;

	void Start ()
	{
		verbs = new List<Verb>();
		available = new List<Verb>();
		verbs.Add(new Burn());
		verbs.Add(new Rest());
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.R)) {
			RefreshAvailable();
		}
	}

	void RefreshAvailable () {
		List<string> aReqs = new List<string>();
		available = new List<Verb>();
		foreach (Slot slot in Inventory.i.slots){
			if(slot.item != null) {
				Debug.Log(slot.item.name);
				ItemProperty[] allProperties = slot.item.GetComponents<ItemProperty>();
				foreach (var prop in allProperties) {
					if(!aReqs.Contains(prop.GetType().ToString())){
						aReqs.Add(prop.GetType().ToString());
					}
				}
			}
		}
		verbs.ForEach(verb => {
			bool ok = true;
			foreach (var req in verb.actorReqs) {
				if(!aReqs.Contains(req)){
					ok = false;
					break;
				}
			}
			if(ok) {
				if(!available.Contains(verb)){
					available.Add(verb);
				}
			} 
			// verb with no actor reqs
			if(verb.actorReqs.Count == 0) {
				if(!available.Contains(verb)){
					available.Add(verb);
				}
			}
		});
	}
}

