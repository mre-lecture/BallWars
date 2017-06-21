using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallSyncManager : Photon.MonoBehaviour {

    bool isThrowing = false;

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (isThrowing)
        {
            if (stream.isWriting)
            {
                stream.SendNext(gameObject.transform.rotation);
                stream.SendNext(gameObject.transform.position);
            }
            else
            {
                gameObject.transform.rotation = (Quaternion)stream.ReceiveNext();
                gameObject.transform.position = (Vector3)stream.ReceiveNext();
            }
        }
    }
}
