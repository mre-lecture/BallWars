using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDespawner : MonoBehaviour {

    public float DespawnTime = 7.0f;

    public void StartDestroyTimer()
    {
        Invoke("DestroyGameObject", DespawnTime);
    }
	
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
