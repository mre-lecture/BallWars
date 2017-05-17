using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	ScoreCounter sc;

	void Start(){
		sc = new ScoreCounter ();
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