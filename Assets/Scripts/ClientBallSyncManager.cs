using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientBallSyncManager : Photon.MonoBehaviour {

	GameObject masterBall;

    private Quaternion nextRotation;
    private Vector3 nextPosition;
	
	// Update is called once per frame
	void Update () {
	    if (PhotonNetwork.isMasterClient)
	    {
	        if (masterBall == null)
	        {
	            masterBall = MasterBallSyncManager.Instance.GetMasterGameBall();
	        }
	        this.transform.position = Vector3.Lerp(this.transform.position, masterBall.transform.position, 1);
	        this.transform.rotation = masterBall.transform.rotation;
	    }
	    else
	    {
	        this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, 0.3f);
		    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, nextRotation, 0.3f);
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
//            gameObject.transform.rotation = (Quaternion)stream.ReceiveNext();
//            gameObject.transform.position = (Vector3)stream.ReceiveNext();
            nextRotation = (Quaternion)stream.ReceiveNext();
            nextPosition = (Vector3)stream.ReceiveNext();
        }
    }
}
