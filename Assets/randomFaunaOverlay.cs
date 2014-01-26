using UnityEngine;
using System.Collections;

public class randomFaunaOverlay : MonoBehaviour {

	float maxCount = 5;
	float currentCount = 0;
	public GameObject prefab;

	// Use this for initialization
	void Start () {
		}
	
	// Update is called once per frame
	void Update () {
		if (Random.value > 0.98f)
			SpawnFauna ();

	}

	void SpawnFauna() {
		Debug.Log("aaaaaaa");
		GameObject obj = (GameObject)Instantiate (prefab,  new Vector2(80,50), Quaternion.identity);
		obj.rigidbody2D.AddForce (new Vector2(Random.Range(-1, 1),Random.Range(-1, 1)).normalized * Random.Range (100, 500));
	}

}
