using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawn : MonoBehaviour {

	public GameObject particleEffect;
	GameObject particle;
	bool stay ;
	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Tile"&& !stay){
			other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			Debug.Log("Boom");
			foreach (ContactPoint contact in other.contacts) {
				
				particle = Instantiate(particleEffect,contact.point,transform.rotation);
				Destroy(particle);
				stay = true;
        	}
		}
		
	}
	private void OnCollisionExit(Collision other) {
		if(other.gameObject.tag == "Tile"){
			stay = false;
		}
	}


	void DestroyParticle(){
		
		
	}
}
