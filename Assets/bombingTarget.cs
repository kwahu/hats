using UnityEngine;
using System.Collections;

public class bombingTarget : MonoBehaviour {

	GameObject player;
	public AudioClip siren;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
	
		//AudioSource.PlayClipAtPoint(siren,this.transform.position);
	} 
}
