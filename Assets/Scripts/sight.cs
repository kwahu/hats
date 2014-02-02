using UnityEngine;
using System.Collections;

public class sight : MonoBehaviour {

	float sight_dist = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlaceSightInFront();
	}

	void PlaceSightInFront()
	{
		Transform trans = this.transform.parent.transform;
		Vector3 pos = this.transform.position;
		pos.x = trans.position.x + trans.rigidbody2D.velocity.normalized.x*sight_dist;
		pos.y = trans.position.y + trans.rigidbody2D.velocity.normalized.y*sight_dist;
		pos.z = 0;
		this.transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.gameObject.tag == "Player")
		{
			transform.parent.gameObject.GetComponent<enemy_playground>().SawPlayer(true);
		}
	}
	void OnTriggerStay2D(Collider2D col) 
	{
		if(col.gameObject.tag == "Player")
		{
			transform.parent.gameObject.GetComponent<enemy_playground>().SawPlayer(true);
		}
	}
}
