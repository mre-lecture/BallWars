using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    public GameObject followingObject;


	void Update () {

        transform.LookAt(followingObject.transform);

	}
}
