	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChecker : MonoBehaviour {

	bool isCheck;
	private void OnTriggerExit(Collider other) {
		if (other.tag == "Floor"){
			
			isCheck = false;
		}
	}
	private void OnTriggerStay(Collider other) {
		if(other.tag == "Floor"){
			
			isCheck = true;
		}
	}

	public bool GetChecker(){
		return isCheck;
	}
}
