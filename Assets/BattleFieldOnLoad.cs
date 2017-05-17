using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldOnLoad : MonoBehaviour {

    [SerializeField] private AudioClip game_music;

	// Use this for initialization
	void Start () {
        SoundManager.instance.ChangeMusic(game_music);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
