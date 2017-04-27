using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeperScript : MonoBehaviour
{

    private int _score = 0;
    private Text _scoreTextComponent;

	// Use this for initialization
	void Start () {
	    _scoreTextComponent = GameObject.Find("ScoreText").GetComponent<Text>();
	}

    public void AddPoints(int amount)
    {
        _score += amount;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    _scoreTextComponent.text = _score.ToString();
	}
}
