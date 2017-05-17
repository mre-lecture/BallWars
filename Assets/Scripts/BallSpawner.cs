using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public GameObject ObjectToSpawn;
    public float SpawnStartDelay = 1.0f;
    public float SpawnDelayBetween = 0.2f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnObject", SpawnStartDelay, SpawnDelayBetween);
	}

    public void SpawnObject()
    {
        var spawnedObject = Instantiate(ObjectToSpawn);
        spawnedObject.transform.position = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}