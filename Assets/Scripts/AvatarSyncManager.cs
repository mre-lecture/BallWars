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

            //For Cubes
            this.transform.position = PlayerSyncManager.Instance.getHead().transform.position;
            this.transform.rotation = PlayerSyncManager.Instance.getHead().transform.rotation;

            /* 
            //For Block People
            this.transform.position = PlayerSyncManager.Instance.getHead().transform.position;
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y - 1.9f, this.transform.position.z);
            this.transform.rotation = PlayerSyncManager.Instance.getHead().transform.rotation;
            this.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0, this.transform.rotation.w);
            */
        }

    }
}
