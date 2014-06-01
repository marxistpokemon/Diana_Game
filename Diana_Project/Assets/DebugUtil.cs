using UnityEngine;
using System.Collections;

public class DebugUtil : MonoBehaviour {

	public static DebugUtil i;

	// Use this for initialization
	void Awake () {
		i = this;
	}
}
