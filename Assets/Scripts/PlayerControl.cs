using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
		[HideInInspector]
		public bool
				facingRight = true;			// For determining which way the player is currently facing.
		[HideInInspector]
		public bool
				jump = false;				// Condition for whether the player should jump.


		public float moveForce = 365f;			// Amount of force added to move the player left and right.
		public float maxSpeed = 3f;				// The fastest the player can travel in the x axis.
		public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
		public float jumpForce = 1000f;			// Amount of force added when the player jumps.
		public AudioClip[] taunts;				// Array of clips for when the player taunts.
		public float tauntProbability = 50f;	// Chance of a taunt happening.
		public float tauntDelay = 1f;			// Delay for when the taunt should happen.


		private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
		private Transform groundCheck;			// A position marking where to check if the player is grounded.
		private bool grounded = false;			// Whether or not the player is grounded.
		private Animator anim;					// Reference to the player's animator component.

		public GameObject rocket;				// Prefab of the rocket.
		public float bulletSpeed = 20f;				// The speed the rocket will fire at.

		public bool playerIsDriving = false;
		float speed = 150;
		float rotationSpeed = 5;
		public float angle;
		public GameObject direction;

		void Awake ()
		{
				anim = GetComponent<Animator> ();

				anim.speed = 0.5f;

				if (playerIsDriving)
						transform.GetChild (0).gameObject.SetActive (true);				
		}

		void Update ()
		{

				if (Input.GetButtonDown ("Fire1"))
					if (playerIsDriving)
						FireBomb ();
					else
						FireBullet ();

		}

		void FixedUpdate ()
		{
				float h = Input.GetAxis ("Horizontal");
				float v = Input.GetAxis ("Vertical");

				if (playerIsDriving)
						Driving (h, v);
				else
						Walking (h, v);
		}

		void Walking (float h, float v)
		{
				if (v > 0)
						anim.Play ("walk_up");
				else if (v < 0)
						anim.Play ("walk_down");
				else if (h > 0)
						anim.Play ("walk_right");
				else if (h < 0)
						anim.Play ("walk_left");

				if (h * rigidbody2D.velocity.x < maxSpeed)
						rigidbody2D.AddForce (Vector2.right * h * moveForce);
		
				if (v * rigidbody2D.velocity.y < maxSpeed)
						rigidbody2D.AddForce (Vector2.up * v * moveForce);
		}
		
		void Driving (float h, float v)
		{
				if (Input.GetKey (KeyCode.RightArrow)) {
						direction.transform.Rotate (new Vector3 (0, 0, 1), -rotationSpeed);
				}
				if (Input.GetKey (KeyCode.LeftArrow)) {
						direction.transform.Rotate (new Vector3 (0, 0, 1), rotationSpeed);
				}

				float dir = direction.transform.eulerAngles.z;

				Vector2 vec = new Vector2 (-Mathf.Sin (dir * Mathf.Deg2Rad) * speed, Mathf.Cos (dir * Mathf.Deg2Rad) * speed);
				this.rigidbody2D.AddForce (vec);

				Debug.Log (dir);
				if (dir > 315 || dir < 45)
						anim.Play ("walk_up");
				else if (dir > 135 && dir < 225)
						anim.Play ("walk_down");
				else if (dir > 45 && dir < 135)
						anim.Play ("walk_left");
				else if (dir > 225 && dir < 315)
						anim.Play ("walk_right");

		}
	
		void FireBullet ()
		{
		GameObject obj = (GameObject)Instantiate (Resources.Load ("bullet_player"), transform.position, Quaternion.Euler (0, 0, 0));
				
				obj.rigidbody2D.AddForce (rigidbody2D.velocity.normalized * 1000);
		}

	void FireBomb ()
	{
		GameObject obj = (GameObject)Instantiate (Resources.Load ("bomb"), transform.position, Quaternion.Euler (0, 0, 0));
		obj.rigidbody2D.AddForce (new Vector2(0,-100));
	}
	
		public IEnumerator Taunt ()
		{
				// Check the random chance of taunting.
				float tauntChance = Random.Range (0f, 100f);
				if (tauntChance > tauntProbability) {
						// Wait for tauntDelay number of seconds.
						yield return new WaitForSeconds (tauntDelay);
			
						// If there is no clip currently playing.
						if (!audio.isPlaying) {
								// Choose a random, but different taunt.
								tauntIndex = TauntRandom ();
				
								// Play the new taunt.
								audio.clip = taunts [tauntIndex];
								audio.Play ();
						}
				}
		}
	
		int TauntRandom ()
		{
				// Choose a random index of the taunts array.
				int i = Random.Range (0, taunts.Length);
		
				// If it's the same as the previous taunt...
				if (i == tauntIndex)
			// ... try another random taunt.
						return TauntRandom ();
				else
			// Otherwise return this index.
						return i;
		}

		/*
	 * 			// If the player should jump...
				if (jump) {
						// Set the Jump animator trigger parameter.
						anim.SetTrigger ("Jump");

						// Play a random jump audio clip.
						int i = Random.Range (0, jumpClips.Length);
						AudioSource.PlayClipAtPoint (jumpClips [i], transform.position);

						// Add a vertical force to the player.
						//	rigidbody2D.AddForce(new Vector2(0f, jumpForce));

						// Make sure the player can't jump again until the jump conditions from Update are satisfied.
						jump = false;
				}

*/
}
