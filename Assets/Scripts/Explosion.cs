using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public AudioClip bombExplosion;

	float count;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(bombExplosion,this.transform.position);
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
