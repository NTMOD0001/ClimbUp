using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public FloorChecker leftChecker;
	public FloorChecker rightChecker;
	public Transform upperFloor;
	
	Rigidbody rb;
	bool stillLeft;
	bool stillRight;
	bool isScored;
	public float speed = 0.5f;
	float velo;
	bool isLeft;
	
	public float force;
	public bool isClimbing;
	
	void Start(){
		velo = speed;
		isClimbing =false;
		rb = GetComponent<Rigidbody>();
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (!isClimbing){
			Move();
		}
	}
	void Move(){
		
		stillLeft = leftChecker.GetChecker();
		stillRight = rightChecker.GetChecker();
		if(stillLeft && !stillRight){
			velo = -speed;
		}else if(stillRight && !stillLeft){
			velo = speed;
		}
		
		rb.MovePosition(transform.position + new Vector3(velo,0,0));
	}
	public void Climbing(){
		//continue here
		isClimbing = true;
		isScored = true;
		rb.isKinematic = true;
		rb.MovePosition(transform.position+ new Vector3(0,20f,0));
		
		Invoke("Continue",0.3f);
		
		
	}

	private void OnTriggerStay(Collider other) {
		if (other.tag == "Ladder")	{
			Climbing();
		}
	}
	void Continue(){
		isClimbing = false;
		rb.isKinematic = false;
	}

	public bool GetScored(){
		bool score = isScored;
		isScored = false;
		return score;
	}
}
