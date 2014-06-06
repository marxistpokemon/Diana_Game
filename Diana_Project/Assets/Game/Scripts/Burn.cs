using UnityEngine;
using System.Collections;

[System.Serializable]
public class Burn : Verb
{
	public Burn () : base (new[] {"Ignitable"}, new[] {"Flamable"}) {
		name = "Burn";
	}

	public override bool Execute (Transform target){
		Debug.Log(targetReqs[0]);
		return false;
	}
}

