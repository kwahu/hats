using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public AudioClip[] taunts;				// Array of clips for when the player taunts.
	public float tauntProbability = 50f;	// Chance of a taunt happening.
	public float tauntDelay = 1f;			// Delay for when the taunt should happen.
	private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.

	private Animator anim;					// Reference to the player's animator component.

	public float bulletSpeed = 20f;				// The speed the rocket will fire at.

	public bool playerIsDriving = false;
	public bool playerIsTalking = false;
	float speed = 150;
	float rotationSpeed = 5;
	public float angle;
	public GameObject direction;
	public GameObject npcInRange = null;
	public float moveForce = 10;
	public float moveBorder = 4.5f;

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
		else if (playerIsTalking) {
			Talk ();
		} else
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

		KeepPlayerWithinLevelBorder();
	}

	void KeepPlayerWithinLevelBorder()
	{
		Vector2 pos = transform.position;
		
		if(pos.x > moveBorder) pos.x = moveBorder;
		if(pos.x < -moveBorder) pos.x = -moveBorder;
		if(pos.y > moveBorder) pos.y = moveBorder;
		if(pos.y < -moveBorder) pos.y = -moveBorder;
		
		transform.position = pos;
	}

	void Talk ()
	{

		if (npcInRange) {
			if (!npcInRange.GetComponent<Dialog> ().started)
				npcInRange.GetComponent<Dialog> ().Init ();

			npcInRange = null;
		}
	}

	//*** START TALKING
	void OnTriggerStay2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "NPC") {
			if (Input.GetButtonDown ("Fire1")) {
				npcInRange = coll.gameObject;
			}
		}
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

		rigidbody2D.AddForce (Vector2.right * h * moveForce);
		rigidbody2D.AddForce (Vector2.up * v * moveForce);
	}
		
	void Driving (float h, float v)
	{
		//rotate plane sprite
		if (Input.GetKey (KeyCode.RightArrow)) {
			direction.transform.Rotate (new Vector3 (0, 0, 1), -rotationSpeed);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			direction.transform.Rotate (new Vector3 (0, 0, 1), rotationSpeed);
		}

		float dir = direction.transform.eulerAngles.z;

		//move player in plane direction
		Vector2 vec = new Vector2 (-Mathf.Sin (dir * Mathf.Deg2Rad) * moveForce, Mathf.Cos (dir * Mathf.Deg2Rad) * moveForce);
		this.rigidbody2D.AddForce (vec);

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
		obj.rigidbody2D.AddForce (new Vector2 (0, -10));
	}
	
	/*	public IEnumerator Taunt ()
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
		}*/
}