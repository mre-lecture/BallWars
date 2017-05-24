using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

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
        if (NumberOfBalls < MaximumAmountOfBalls)
        {
            var spawnedObject = Instantiate(ObjectToSpawn);
            spawnedObject.transform.position = gameObject.transform.position;
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
}