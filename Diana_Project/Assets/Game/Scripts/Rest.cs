using UnityEngine;
using System.Collections;

[System.Serializable]
public class Rest : Verb
{
	public Rest () : base (new string[] {}, new string[] {}) {
		name = "Rest";
	}
	
	public override void Do (Transform actor, Transform target){
		Debug.Log("rest");
	}
}

