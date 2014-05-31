using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public Transform target;
	public float smooth = 2f;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		//offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		target = ChunkManager.i.player.transform;
		transform.position = Vector3.Lerp (transform.position, 
		                                   target.position + offset, 
		                                   Time.deltaTime * smooth);
		transform.LookAt(target); // gira para olhar o target
	}
}
