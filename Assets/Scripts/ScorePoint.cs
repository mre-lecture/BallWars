using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour {

	public enum Player{ Player_1, Player_2};
	public enum Color{ 	Red, Green};
	public enum Position{One, Two, Three};

	public Player player;
	public Position position;

	private int positionNumber;
	private Material redMat;
	private Material greenMat;
	private string red_mat = "score_red";
	private string green_mat = "score_green";
	private Renderer renderer;

	public void Start(){
		redMat = Resources.Load (red_mat) as Material;
		greenMat = Resources.Load(green_mat) as Material;

		transform.gameObject.tag = "ScorePoint";
		renderer = GetComponent<Renderer> ();
		SetColor (Color.Red);
		renderer.material = redMat;

		SetPositionNumner ();
	}


	private void SetPositionNumner(){
	
		switch(position){
		case Position.One: 
			positionNumber = 1;
			break;
		case Position.Two:
			positionNumber = 2;
			break;
		case Position.Three: 
			positionNumber = 3;
			break;
		}	
	}

	public void UpdateScore(int player_one_score){

		if (player_one_score >= positionNumber) {
			SetColor (Color.Green);
		}
	}

	private void SetColor(Color col){
		switch (col) {
		case Color.Red:
			renderer.material = redMat;
			break;
		case Color.Green:
			renderer.material = greenMat;
			break;
		}
	}
}