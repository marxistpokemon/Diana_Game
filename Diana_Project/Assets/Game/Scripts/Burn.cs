using UnityEngine;
using System.Collections;

[System.Serializable]
public class Burn : Verb
{
	public Burn () : base (new[] {"Ignitable"}, new[] {"Flamable"}) {
		name = "Burn";
	}

	public override void Do (Transform actor, Transform target){
		Debug.Log("destroy");
	}
}

