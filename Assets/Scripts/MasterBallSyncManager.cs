using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBallSyncManager : MonoBehaviour {

    GameObject gameBall;

    public static MasterBallSyncManager Instance;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            gameBall = gameObject;
        }
    }

    public GameObject GetMasterGameBall()
    {
        return gameBall;
    }

    public void HitBall(Vector3 hitNormale)
    {
        Debug.Log("hitBall");
        gameBall.GetComponent<Rigidbody>().AddForce(hitNormale, ForceMode.Impulse);
    }
}
