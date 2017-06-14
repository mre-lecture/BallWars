using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterCommunicator : Photon.MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if(PhotonNetwork.isMasterClient)
        {
            this.transform.position = GameBallSyncManager.Instance.getGameBall().transform.position;
            this.transform.rotation = GameBallSyncManager.Instance.getGameBall().transform.rotation;
        }
	}



    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.CompareTag("Ball"))
        {
            Vector3 hitpoint = other.contacts[0].normal;
            hitpoint = Vector3.Scale(hitpoint, new Vector3(-1, -100, -1));
            hitBall(hitpoint);
        }
    }

    void hitBall(Vector3 hitpoint)
    {
        photonView.RPC("BallWasHitMessage",  PhotonTargets.MasterClient, hitpoint);
    }

    [PunRPC]
    void BallWasHitMessage(Vector3 hitpoint)
    {
        GameBallSyncManager.Instance.hitBall(hitpoint);
    }

    private Vector3 GetPointOfContact()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            return hit.point;
        }
        return new Vector3(0,0,0);
    }
}
