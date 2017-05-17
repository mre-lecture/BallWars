using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerManager : SteamVR_TrackedController {

    public AudioClip throwingSound;

	// Use this for initialization
	void Start () {

	}

    override
    public void OnTriggerUnclicked(ClickedEventArgs e)
    {
        base.OnTriggerUnclicked(e);
        SoundManager.instance.RandomizeSfx(throwingSound);
    }
}
