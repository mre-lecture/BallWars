using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : Photon.MonoBehaviour {

    public GameObject ObjectToSpawn;
    public float SpawnStartDelay = 1.0f;
    public float SpawnDelayBetween = 0.2f;
    public int MaximumAmountOfBalls = 20;

    private int NumberOfBalls = 0; // Too many balls is not good....

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnObject", SpawnStartDelay, SpawnDelayBetween);
	}

    public void SpawnObject()
    {
		if (PhotonNetwork.isMasterClient) {
			if (NumberOfBalls < MaximumAmountOfBalls) {
				var spawnedObject = PhotonNetwork.Instantiate ("Tennisball", gameObject.transform.position, Quaternion.identity, 0);
			}
		}
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        ++NumberOfBalls;
    }

    void OnTriggerExit(Collider other)
    {
        --NumberOfBalls;
    }

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext (NumberOfBalls);
		} else {
			int numberOfballs = (int)stream.ReceiveNext ();
			if (numberOfballs < MaximumAmountOfBalls) {
				NumberOfBalls = numberOfballs;
			}
		}
	}
}