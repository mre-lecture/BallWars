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
            var speed = other.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            hitpoint = Vector3.Scale(hitpoint, new Vector3(speed, speed, speed));
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
}
