using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionManager : MonoBehaviour
{
	List<Verb> allVerbs;
	List<Target> allTargets;

	// Use this for initialization
	void Start ()
	{
		allVerbs.Add(new Verb("Burn", "Torch"));
	}

	// Update is called once per frame
	void Update ()
	{

	}
}

