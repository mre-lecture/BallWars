using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {

	private int pointsPlayer_one = 0;

	private int pointsPlayer_two = 0;


	public int GetPointsOfPlayerOne(){
		return pointsPlayer_one;
	}

	public int GetPointsOfPlayerTwo(){
		return pointsPlayer_two;
	}

	public void increasePointsPlayerOne(){
		pointsPlayer_one++;
	
	}

	public void increasePointsPlayerTwo(){
		pointsPlayer_two++;
	}

}
