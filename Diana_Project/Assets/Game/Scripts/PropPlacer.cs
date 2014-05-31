using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class PropPlacer : MonoBehaviour {
	public bool runAtStart = false;
	public float delay = 0f;
	public bool countTries = false;
	public bool forceParenting = false;
	public Transform prop;
	public int quantity;

	public float normalFactor = 0f;

	public float radius;
	public float xSize, zSize;
	public float depth = 0.2f;
	public LayerMask mask;

	Vector3 topPos;

	public void Start() {
		if(runAtStart) StartCoroutine(Delay());
	}

	IEnumerator Delay () {
		yield return new WaitForSeconds(delay);
		Place ();
	}

	public void Place () {
		Transform placed = null;
		int i = 0;
		while (i < quantity) {
			topPos = new Vector3(transform.position.x + Random.Range(-xSize/2, xSize/2), 
			                     transform.position.y, 
			                     transform.position.z + Random.Range(-zSize/2, zSize/2));
			RaycastHit hit;
			if (Physics.SphereCast(topPos, radius, -Vector3.up, out hit) && hit.transform.CompareTag("Ground")) {
				placed = Instantiate(prop, hit.point + new Vector3(0, -depth, 0), Quaternion.identity) as Transform;
				if(normalFactor != 0) {
					placed.up = Vector3.Lerp(Vector3.up, hit.normal, normalFactor);
				}
				if(placed.CompareTag("Player")) ChunkManager.i.player = placed.GetComponent<Player>();
				if(forceParenting) placed.parent = transform.parent;
				if(!countTries) i++;
			}
			if(countTries) i++;
		}
		enabled = false;
	}
}
