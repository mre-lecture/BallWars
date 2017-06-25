using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisballAvatarSyncManager : Photon.MonoBehaviour {

    GameObject relatedTennisball;
    bool relatedTennisballSet = false;
	
	// Update is called once per frame
	void Update () {
        if (photonView.isMine)
        {
            if(relatedTennisball != null)
            {
                gameObject.transform.position = relatedTennisball.transform.position;
                gameObject.transform.rotation = relatedTennisball.transform.rotation;
            }
            else if (relatedTennisballSet)
            {
                PhotonNetwork.Destroy(gameObject);
            }
            
        }
	}

    public void setRelatedTennisballForAvatar(GameObject tennisball)
    {
        relatedTennisball = tennisball;
        relatedTennisballSet = true;
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (photonView.isMine)
        {
            if (stream.isWriting)
            {
                stream.SendNext(gameObject.transform.position);
                stream.SendNext(gameObject.transform.rotation);
            }
        }
        else
        {
            if (stream.isReading)
            {
                gameObject.transform.position = (Vector3)stream.ReceiveNext();
                gameObject.transform.rotation = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}
