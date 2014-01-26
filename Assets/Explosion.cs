using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	float count;
	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		if(count > 1)
		{
			Destroy(this.gameObject);
		}
	}
}
