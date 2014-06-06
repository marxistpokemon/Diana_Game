using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ActionManager : MonoBehaviour
{
	[SerializeField]
	public List<Verb> verbs;

	void Start ()
	{
		verbs = new List<Verb>();
		verbs.Add(new Burn());
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.R)) {
			Debug.Log(verbs[0].Execute(ChunkManager.i.player.transform));
		}
	}
}

