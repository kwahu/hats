using UnityEngine;
using System.Collections;

public class BombFly : MonoBehaviour {

	public AudioClip bombFly;

	float count;
	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(bombFly,this.transform.position);

		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime/2;

		this.transform.localScale = new Vector3( Mathf.Lerp(1,0.1f,count), Mathf.Lerp(1,0.1f,count), 0);

		if(count > 1)
		{
			GameObject obj = (GameObject)Instantiate (Resources.Load ("explosion1"), transform.position, Quaternion.Euler (0, 0, 0));

			Destroy(this.gameObject);
		}
	}
}
