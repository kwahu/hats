﻿using UnityEngine;
using System.Collections;

public class backgroundSounds : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.GetComponent<gameController>().currentTheme == gameController.Theme.PLANES)
			if (!audio.isPlaying && (Random.value > 0.97f))
				audio.Play();
	}
}
