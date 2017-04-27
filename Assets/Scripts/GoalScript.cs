using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{

    public int Points = 10;

    private GameObject _scoreKeeper;

	// Use this for initialization
	void Start ()
	{
	    _scoreKeeper = GameObject.Find("ScoreKeeper");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        var scoreKeeperScript =  _scoreKeeper.GetComponent<ScoreKeeperScript>();
        scoreKeeperScript.AddPoints(Points);
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
