using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour {
	bool spawnable = false;
	private void OnTriggerStay(Collider other) {
		if (other.tag == "Tile"){
			spawnable = false;
		}
	}
	private void OnTriggerExit(Collider other) {
		if (other.tag == "Tile"){
			spawnable = true;
		}
	}

	public bool GetSpawnable()
	{
		return spawnable;
	}
}
