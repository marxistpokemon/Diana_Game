using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Verb
{
	public string name;
	public List<string> actorReqs;
	public List<string> targetReqs;

	public Verb (string[] aReqs, string[] tReqs) {
		actorReqs = new List<string>();
		actorReqs.AddRange(aReqs);
		targetReqs = new List<string>();
		targetReqs.AddRange(tReqs);
	}

	public virtual void Do (Transform actor, Transform target) {}

	public bool Execute (Transform actor, Transform target) {

		if( (target != null && !CheckTargetReqs(target)) || (actor != null && !CheckActorReqs(actor))) {
			return false;
		}
		Do(actor, target);
		return true;
	}

	public bool CheckActorReqs (Transform actor) {
		foreach (var aReq in actorReqs) {
			if(actor.GetComponent(aReq) == null) {
				return false;
			}
		}
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