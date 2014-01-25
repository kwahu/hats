using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy (this.gameObject,0.1f);
	}
}
