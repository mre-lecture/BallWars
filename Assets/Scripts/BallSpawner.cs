using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public GameObject ObjectToSpawn;
    [Range(0.1f, 60f)]
    public float TimeBeforeFirstSpawn = 1f;
    [Range(0.1f, 10f)]
    public float TimeBetweenSpawns = 1f;

    public int MaximumAmountOfObjects = 100;

    private int _spawnedBalls = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnBall", TimeBeforeFirstSpawn, TimeBetweenSpawns);
	}

    void SpawnBall()
    {
        var gameObjectInstance = Instantiate(ObjectToSpawn);
        gameObjectInstance.transform.position = gameObject.transform.position;
        if (++_spawnedBalls > MaximumAmountOfObjects)
            CancelInvoke("SpawnBall");
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
