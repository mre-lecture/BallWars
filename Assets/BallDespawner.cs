using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDespawner : MonoBehaviour {

    public float DespawnTime = 7.0f;

	// Use this for initialization
	void Start () {

        Invoke("DestroyGameObject", DespawnTime);
	}
	
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
