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

	public virtual bool Execute (Transform target) {
		return false;
	}
}