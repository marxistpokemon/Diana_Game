using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	public static int itemCount;
	public string name;

	void Start() {
		Item.itemCount++;
		gameObject.name = name;
	}
}

