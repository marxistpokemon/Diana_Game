using UnityEngine;
using System.Collections;

public class Verb {
	public string name;
	public string required;

	public Verb (string pName, string pReq) {
		name = pName;
		required = pReq;
	}
}

public class Target {
	public string name;
	public Target (string pName) {
		name = pName;
	}
}

public class PlayerAction {
	public Verb verb;
	public Target target;
}