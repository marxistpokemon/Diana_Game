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
		allVerbs = new List<Verb>();
		allVerbs.Add(new Burn());
	}

	// Update is called once per frame
	void Update ()
	{
		/*
		if(Input.GetKeyDown(KeyCode.A)){
			allVerbs.ForEach(v => print(v.ToString()));
		}
		*/
	}
}

