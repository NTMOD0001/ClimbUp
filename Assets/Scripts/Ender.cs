using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ender : MonoBehaviour {
	bool end;

	void start (){
		end = false;
	}
	private void OnTriggerStay(Collider other) {
		if (other.tag == "Player"){
			end = true;
		}
	}

	public bool GetEnder(){
		return end;
	}
}
