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
        if(gameBall.transform.position.x > hitpoint.x)
        {
            gameBall.transform.position = gameBall.transform.position + new Vector3(-0.5f, 0, 0);
        }
        else
        {
            gameBall.transform.position = gameBall.transform.position + new Vector3(0.5f, 0, 0);
        }
        
    }
}
