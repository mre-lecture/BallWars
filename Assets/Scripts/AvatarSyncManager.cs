using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSyncManager : Photon.MonoBehaviour {

	GameObject playerObject;

	void Start(){
		if (photonView.isMine) {
			GameObject dudeObject = transform.GetChild (0).gameObject;
			gameObject.layer = 15;
			dudeObject.layer = 15;
		}
	}

    // Update is called once per fram
    void Update()
    {
		
        if (photonView.isMine)
        {
			if (playerObject == null) {
				playerObject = PlayerSyncManager.Instance.getHead ();
			} else {
				//For Block People
				this.transform.position = playerObject.transform.position;
				this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y-1.9f, this.transform.position.z);
				this.transform.rotation = playerObject.transform.rotation;
				this.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0, this.transform.rotation.w);
			}
        }
    }
}
