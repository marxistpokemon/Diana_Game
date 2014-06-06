using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Verb
{
	public string name;
	public bool available;
	public List<string> actorReqs;
	public List<string> targetReqs;

	public Verb (string[] aReqs, string[] tReqs) {
		actorReqs = new List<string>();
		actorReqs.AddRange(aReqs);
		targetReqs = new List<string>();
		targetReqs.AddRange(tReqs);
	}

	public virtual void Do (Transform target) {}

	public bool Execute (Transform target) {
		if(!CheckTargetReqs(target)) {
			return false;
		}
		Do(target);
		return true;
	}

	public bool CheckTargetReqs (Transform target) {
		foreach (var tReq in targetReqs) {
			if(target.GetComponent(tReq) == null) {
				return false;
			}
		}
		return true;
	}
}