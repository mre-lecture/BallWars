using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallSyncManager : Photon.MonoBehaviour {

    public void CreateSyncAvatar()
    {
       GameObject avatar =  PhotonNetwork.Instantiate("TennisballAvatar", gameObject.transform.position, gameObject.transform.rotation, 0);
       avatar.GetComponent<TennisballAvatarSyncManager>().setRelatedTennisballForAvatar(gameObject);
    }
}
