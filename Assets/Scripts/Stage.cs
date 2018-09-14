using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {
	Collider collider;
	private void OnTriggerExit(Collider other) {
		if (other.tag == "Player"){
			GetComponent<Collider>().isTrigger = false;;
		}
		
	}
}
