using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBallSyncManager : MonoBehaviour {

    GameObject gameBall;

    public static GameBallSyncManager Instance;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            gameBall = gameObject;
        }
    }

    public GameObject getGameBall()
    {
        return gameBall;
    }

    public void hitBall(Vector3 hitpoint)
    {
        Debug.Log("hitBall");
        gameBall.GetComponent<Rigidbody>().AddForce(hitpoint, ForceMode.Impulse);
    }
}
