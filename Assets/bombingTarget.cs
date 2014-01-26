using UnityEngine;
using System.Collections;

public class bombingTarget : MonoBehaviour {

	GameObject player;
	AudioSource audioSource;
	public AudioClip siren;
	
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = siren;
		player = GameObject.Find ("Player");	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (!audio.isPlaying && (other.gameObject == player)){
			audio.Play();
		}
	} 
}
