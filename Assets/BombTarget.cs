using UnityEngine;
using System.Collections;

public class BombTarget : MonoBehaviour {


	public Sprite spr;
	public bool destroyed = false;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "PlayerBullets")
		{

			if(!destroyed)	Camera.main.GetComponent<gameController>().targets -= 1;

			this.GetComponent<SpriteRenderer>().sprite = spr;

			destroyed = true;
		}
	}
		 
}
