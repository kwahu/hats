using UnityEngine;
using System.Collections;

public class enemy_playground : MonoBehaviour
{
	
		private Animator anim;
		public bool ShouldFollowPlayerOnSight = true;
		public bool ShouldShootPlayerOnSight = true;
		public bool ShouldRunFromPlayerOnSight = false;
		float speed = 10;
		float planeSpeed = 100;
		float delayMax = 3;
		float delayMin = 1;
		float delay = 0;
		Vector2 direction;
		bool sawPlayer = false;
		GameObject player;
		float fireCooldown = 1;
		public GameObject plane;
		public GameObject tentacleLeft;
		public GameObject tentacleRight;
		public bool isDriving = false;
		public float turnValue = 0;
		public bool adjustLeft = false;
		public bool adjustRight = false;
		public bool adjusting = false;

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

				if (isDriving)
						plane.SetActive (true);
				else
						plane.SetActive (false);
		}

		void Update ()
		{
				fireCooldown -= Time.deltaTime;

				Animate ();

				if (ShouldFollowPlayerOnSight && sawPlayer)
						Follow ();
				else if (ShouldRunFromPlayerOnSight && sawPlayer)
						RunAway ();
				else
						Move ();

				AdjustAngle ();
		}

		//*** MOVE
		void Move ()
		{
				delay -= Time.deltaTime;
		
				if (delay < 0 && !adjustLeft && !adjustRight)
						ChangeDirection ();
		
				if (isDriving) {
						Driving ();
				} else {
						rigidbody2D.AddForce (direction * speed);
				}
		}

		//*** DRIVING
		void Driving ()
		{
				plane.transform.Rotate (new Vector3 (0, 0, 1), turnValue);

				tentacleLeft.transform.RotateAround (this.transform.position, new Vector3 (0, 0, 1), turnValue);
				tentacleRight.transform.RotateAround (this.transform.position, new Vector3 (0, 0, 1), turnValue);
		
				float dir = plane.transform.eulerAngles.z;
		
				Vector2 vec = new Vector2 (-Mathf.Sin (dir * Mathf.Deg2Rad) * planeSpeed, Mathf.Cos (dir * Mathf.Deg2Rad) * planeSpeed);
				this.rigidbody2D.AddForce (vec);
		}

		//*** CHANGE DIRECTION
		void ChangeDirectionDrive ()
		{
				if (turnValue == 0) {
						turnValue = Random.Range (-4f, 4f);
						delay = Random.Range (delayMin / 3, delayMax / 3);
				} else {
						turnValue = 0;
						delay = Random.Range (delayMin, delayMax);
				}
		}
	
		//*** ADJUST ANGLE ACCORDING TO TENTACLE
		public void AdjustAngle ()
		{
				if (adjustLeft) {
						turnValue = -5;
				} else if (adjustRight) {
						turnValue = 5;
				} else {
						StopAdjusting ();
				}

				adjustLeft = false;
				adjustRight = false;
		}

		void StopAdjusting ()
		{
				if (adjusting) {
						turnValue = 0;
						adjusting = false;
				}
		}


		//*** CHANGE DIRECTION
		void ChangeDirection ()
		{
				if (isDriving)
						ChangeDirectionDrive ();
				else
						ChangeDirectionWalk ();
		}

	
		//*** FOLOW
		void Follow ()
		{
				sawPlayer = false;
		
				if (ShouldShootPlayerOnSight && fireCooldown < 0)
						FireBullet ();
		
				if (isDriving)
						Driving ();
				else
						Walking ();
		}

		//*** WALKING
		void Walking ()
		{
				rigidbody2D.AddForce ((player.transform.position - this.transform.position) * speed);
		}
	
		//*** FIRE BULLET
		void FireBullet ()
		{
				AudioSource.PlayClipAtPoint(gunShot,this.transform.position);
				GameObject obj = (GameObject)Instantiate (Resources.Load ("bullet_enemy"), transform.position, Quaternion.Euler (0, 0, 0));
				//obj.layer = LayerMask.NameToLayer("Bullets");
				obj.rigidbody2D.AddForce (rigidbody2D.velocity.normalized * 1000);
		
				fireCooldown = Random.Range (1f, 2f);
		}
	
		//*** RUN AWAY
		void RunAway ()
		{
				sawPlayer = false;
		
				rigidbody2D.AddForce (-(player.transform.position - this.transform.position) * speed);
		}
	

	
		//*** CHANGE DIRECTION
		void ChangeDirectionWalk ()
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
