using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowImage : MonoBehaviour {

	public Texture2D image;

	void Start(){
	}

	void OnGUI(){
		gameObject.GetComponent<Renderer> ().material.mainTexture = image;
	}
}
