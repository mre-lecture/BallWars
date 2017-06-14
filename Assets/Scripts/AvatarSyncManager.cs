using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSyncManager : Photon.MonoBehaviour {

    // Update is called once per fram
    void Update()
    {
        if (photonView.isMine)
        {
            GameObject manager = PlayerSyncManager.Instance.getHead();
            this.transform.position = PlayerSyncManager.Instance.getHead().transform.position;
            this.transform.rotation = PlayerSyncManager.Instance.getHead().transform.rotation;
        }

    }
}
