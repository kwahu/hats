using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour
{

	public Sprite[] text;
	public AudioSource[] sound;
	int slideNum = 0;
	public bool started = false;
	public GameObject dialogPoster;

	public void Init ()
	{
		dialogPoster = this.transform.GetChild (0).gameObject;
		started = true;
		dialogPoster.GetComponent<SpriteRenderer> ().sprite = text [slideNum];
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (started && Input.GetButtonDown ("Fire1") && slideNum < text.Length) {
			slideNum += 1;
			dialogPoster.GetComponent<SpriteRenderer> ().sprite = text [slideNum];
		}
	}
}
