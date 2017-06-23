using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	ScoreCounter sc;
	GameObject[] scores;

	void Start(){
		transform.gameObject.tag = "GameManager";
		sc = new ScoreCounter ();
		scores = GameObject.FindGameObjectsWithTag ("ScorePoint");
	}

	public ScoreCounter GetScoreCounter(){
		return sc;
	}

	//Update the ScorePoints on the Table
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
		if (IsGameOver ()) {
			SceneManager.LoadScene ("MenuScene", LoadSceneMode.Single);
		}

	}

	bool IsGameOver(){
		if (sc.GetPointsOfPlayerOne() >= 3) {
			return true;
		}
		if (sc.GetPointsOfPlayerTwo() >= 3) {
			return true;
		}
		return false;
	}
	
}