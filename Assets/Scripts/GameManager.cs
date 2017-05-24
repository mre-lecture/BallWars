using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	ScoreCounter sc;
	GameObject[] scores;

	void Start(){
		sc = new ScoreCounter ();
		scores = GameObject.FindGameObjectsWithTag ("ScorePoint");
	}

	public ScoreCounter GetScoreCounter(){
		return sc;
	}

	private void UpdateScores(){
		foreach(GameObject obj in scores){
			ScorePoint score = obj.GetComponent<ScorePoint>();
			if (score.player == ScorePoint.Player.Player_1){
				score.UpdateScore (sc.GetPointsOfPlayerOne());
			} else {
				score.UpdateScore (sc.GetPointsOfPlayerTwo());
			}
		}
	}

	void Update(){
		UpdateScores ();
	}

	void LateUpdate(){
		IsGameOver ();
	}

	bool IsGameOver(){
		if (sc.GetPointsOfPlayerOne() >= 3) {
			print ("GameIsOver");
		}
	
		return false;
	}
}