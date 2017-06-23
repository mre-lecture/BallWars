using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldOnLoad : MonoBehaviour {

    [SerializeField] private AudioClip game_music;
    private GameObject[] audiences;
    private GameObject goalball;

	// Use this for initialization
	void Start () {
        SoundManager.instance.ChangeMusic(game_music);
	}
	
	// Update is called once per frame
	void Update () {
		/*
        goalball = GameObject.Find("Goalball");
        Transform ball = goalball.GetComponent<Transform>();

        audiences = GameObject.FindGameObjectsWithTag("AudienceAudio");
        foreach (GameObject audience in audiences)
        {
            AudioSource source = audience.GetComponent<AudioSource>();
            if (source != null && ball != null)
            {
                //distance in percentage from 0 to 1
                float distanceFromCenter = System.Math.Abs(ball.position.x/4);
                //minVolume
                if (distanceFromCenter <= 0.3)
                {
                    source.volume = 0.3f;
                }else
                {
                    source.volume = distanceFromCenter;
                }
            }else
            {
                print("Audio Source or Goalball is null");
            }
        }
        */
    }
}
