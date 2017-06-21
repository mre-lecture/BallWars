using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientBallSyncManager : Photon.MonoBehaviour {

    Vector3 lastLoadPosition;
    Quaternion lastLoadRotation;
	
	// Update is called once per frame
	void Update () {
        if(PhotonNetwork.isMasterClient)
        {
            this.transform.position = MasterBallSyncManager.Instance.GetMasterGameBall().transform.position;
            this.transform.rotation = MasterBallSyncManager.Instance.GetMasterGameBall().transform.rotation;
        }
        else
        {
            if(lastLoadPosition != null)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, lastLoadPosition, 1.0f);
            }
        }
	}

    //Inform that something collite with the client ball
    void OnCollisionEnter(Collision other)
    {
        //If a tennis ball hit the client ball, inform the master client about that
        if (other.gameObject.CompareTag("Ball"))
        {
            
            //Get normale of the last collision object
            Vector3 hitNormale = other.contacts[0].normal;

            //Get speed of the last collision object
            var speed = other.gameObject.GetComponent<Rigidbody>().velocity.magnitude;

            //Multiplayer normale with speed of the collision object
            hitNormale = Vector3.Scale(hitNormale, new Vector3(speed, speed, speed));

            //Send information about the collision to the master client
            photonView.RPC("BallWasHitMessage", PhotonTargets.MasterClient, hitNormale);
        }
    }

    [PunRPC]
    void BallWasHitMessage(Vector3 hitNormale)
    {
        //Inform Master Ball that the client ball was hit
        MasterBallSyncManager.Instance.HitBall(hitNormale);
    }
    
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(gameObject.transform.rotation);
            stream.SendNext(gameObject.transform.position);
        }
        else
        {
            gameObject.transform.rotation = (Quaternion)stream.ReceiveNext();
            lastLoadPosition = (Vector3)stream.ReceiveNext();
        }
    }
}
