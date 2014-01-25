using UnityEngine;
using System.Collections;

public class enemy_playground : MonoBehaviour {

	
	private Animator anim;


	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
		
		anim.speed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 vec = new Vector2(Random.Range(0,1),Random.Range(0,1)); 
		rigidbody2D.AddForce(vec);


		if (rigidbody2D.velocity.normalized.y < 0)
		{
			anim.Play("walk_up");
		}
		else if (rigidbody2D.velocity.normalized.y > 0)
		{
			anim.Play("walk_down");
		}
		else if (rigidbody2D.velocity.normalized.x > 0)
		{
			anim.Play("walk_right");
		}
		else if (rigidbody2D.velocity.normalized.x < 0)
		{
			anim.Play("walk_left");
		}
	}
}
