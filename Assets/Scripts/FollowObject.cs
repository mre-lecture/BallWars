using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    GameObject followingObject;

    void Start()
    {
        followingObject = GameBallSyncManager.Instance.getGameBall();
    }
       
	void Update () {
        if(followingObject != null) 
            transform.LookAt(followingObject.transform);

	}
}
