using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSyncManager : Photon.MonoBehaviour {

    // Update is called once per fram
    void Update()
    {
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        //this.GetComponent<Renderer>().enabled = false;
        if (photonView.isMine)
        {
            GameObject playerObject = PlayerSyncManager.Instance.getHead();

            //For Cubes
            /*this.transform.position = PlayerSyncManager.Instance.getHead().transform.position;
            this.transform.rotation = PlayerSyncManager.Instance.getHead().transform.rotation;
            */

            //For Block People
            this.transform.position = playerObject.transform.position;
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y-1.6f, this.transform.position.z);
            this.transform.rotation = playerObject.transform.rotation;
            this.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0, this.transform.rotation.w);

            GameObject dudeObject = transform.GetChild(0).gameObject;
            gameObject.layer = 15;
            dudeObject.layer = 15;
        }
    }
}
