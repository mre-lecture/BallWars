using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBallSelection : MonoBehaviour {

    static public string gameball = "basketball";

    static public void changeGameBallSelected(string gameBall)
    {
        if (!gameBall.Equals(""))
        {
            Debug.Log("gameball is not empty");
            gameball = gameBall;
        }
    }
}
