using UnityEngine;
using System.Collections;

public class BombTarget : MonoBehaviour {


	public Sprite spr;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "PlayerBullets")
		{
			Debug.Log("DESTROYED!!!");

			this.GetComponent<SpriteRenderer>().sprite = spr;
		}
	}
		 
}
