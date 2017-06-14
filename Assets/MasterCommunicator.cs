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

    void OnTriggerEnter(Collider other)
    {
        Vector3 hitpoint = GetPointOfContact();
        hitBall(hitpoint);
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
