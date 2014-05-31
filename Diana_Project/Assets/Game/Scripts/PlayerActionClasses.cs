using UnityEngine;
using System.Collections;

public class PlayerAction {
	public Verb verb;
	public Target target;
}

public class Burn : Verb {
	public Burn () : base ("Burn", new string[] {"IEquipable"}){
	}
}