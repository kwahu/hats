using UnityEngine;
using System.Collections;

public class bombingTarget : MonoBehaviour {

	GameObject player;
	Vector3 distanceSqr;
	public AudioClip siren;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		Debug.Log("Something has entered this zone.");    
	} 
}
