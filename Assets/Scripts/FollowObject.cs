using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    GameObject followingObject;

    void Start()
    {
        followingObject = MasterBallSyncManager.Instance.GetMasterGameBall();
    }
       
	void Update () {
        if(followingObject != null) 
            transform.LookAt(followingObject.transform);

	}
}
