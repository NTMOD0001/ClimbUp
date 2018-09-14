using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour {

	// Use this for initialization
	float xpos;
	bool goLeft;
	public float radius;
	public float speed;
	
	// Update is called once per frame
	void Update () {
		if(!goLeft){
			if(xpos < radius){
				transform.position += new Vector3(speed,0,0);
			}else{
				goLeft = true;
			}	
		}else{
			if(xpos > -radius){
				transform.position += new Vector3(-speed,0,0);
			}else{
				goLeft =false;
			}
		}
		
		xpos = transform.position.x;

		
	}
}
