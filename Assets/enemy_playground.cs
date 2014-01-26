using UnityEngine;
using System.Collections;

public class enemy_playground : MonoBehaviour
{
	
		private Animator anim;
		public bool ShouldFollowPlayerOnSight = true;
		public bool ShouldShootPlayerOnSight = true;
		public bool ShouldRunFromPlayerOnSight = false;
		float speed = 10;
		float delayMax = 3;
		float delayMin = 1;
		float delay = 0;
		Vector2 direction;
		bool sawPlayer = false;
		GameObject player;

	    public AudioClip gunShot;


		public void SawPlayer (bool set)
		{
				sawPlayer = set;
		}

		void Awake ()
		{
				anim = GetComponent<Animator> ();
				anim.speed = 0.5f;
				player = GameObject.Find ("Player");
		}

		void Update ()
		{
				Animate ();

				if (ShouldFollowPlayerOnSight && sawPlayer)
						Follow ();
				else if (ShouldRunFromPlayerOnSight && sawPlayer)
						RunAway ();
				else
						Move ();
		}

		void Follow ()
		{
				sawPlayer = false;

				rigidbody2D.AddForce ((player.transform.position - this.transform.position) * speed);

				if (ShouldShootPlayerOnSight && (Random.value > 0.95f))
						FireBullet ();

		}

		void FireBullet ()
		{
				AudioSource.PlayClipAtPoint(gunShot,this.transform.position);
				GameObject obj = (GameObject)Instantiate (Resources.Load ("bullet_enemy"), transform.position, Quaternion.Euler (0, 0, 0));
				//obj.layer = LayerMask.NameToLayer("Bullets");
				obj.rigidbody2D.AddForce (rigidbody2D.velocity.normalized * 1000);
		}

		void RunAway ()
		{
				sawPlayer = false;
		
				rigidbody2D.AddForce (-(player.transform.position - this.transform.position) * speed);
		}

		void Move ()
		{
				delay -= Time.deltaTime;

				if (delay < 0)
						ChangeDirection ();

				rigidbody2D.AddForce (direction * speed);
		}

		void ChangeDirection ()
		{
				direction = new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f)); 
				direction.Normalize ();
				delay = Random.Range (delayMin, delayMax);
		}

		void Animate ()
		{
				if (rigidbody2D.velocity.normalized.y < 0) {
						anim.Play ("walk_up");
				} else if (rigidbody2D.velocity.normalized.y > 0) {
						anim.Play ("walk_down");
				} else if (rigidbody2D.velocity.normalized.x > 0) {
						anim.Play ("walk_right");
				} else if (rigidbody2D.velocity.normalized.x < 0) {
						anim.Play ("walk_left");
				}
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
				ChangeDirection ();

				if (coll.gameObject.layer == LayerMask.NameToLayer ("PlayerBullets"))
						Destroy (this.gameObject);
		}

		void OnCollisionStay2D (Collision2D coll)
		{
				ChangeDirection ();
		}


}
