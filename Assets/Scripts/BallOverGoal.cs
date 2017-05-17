﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BallOverGoal : MonoBehaviour {

    public GameObject goalBall;
	private Vector3 position;

	void Start(){
		position = goalBall.transform.position;
	}

	void OnCollisionEnter(Collision other)
    {	
		if (goalBall == other.gameObject) { 
			Rigidbody rb =  goalBall.GetComponent<Rigidbody> ();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			goalBall.transform.position = position;
		}
	}
}