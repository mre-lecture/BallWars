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
	private Material mat;
	private string red_mat = "score_red";
	private string green_mat = "score_green";
	private Renderer renderer;

	public void Start(){
		
		renderer = GetComponent<Renderer> ();
		SetColor (Color.Red);
		renderer.material = mat;

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
			mat = Resources.Load (red_mat) as Material;
			renderer.material = mat;
			break;
		case Color.Green:
			mat = Resources.Load(green_mat) as Material;
			renderer.material = mat;
			break;
		}
	}
}