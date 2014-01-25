using UnityEngine;
using System.Collections;

public class sight : MonoBehaviour {

	public float sight_dist = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform trans = this.transform.parent.transform;
		Vector3 pos = this.transform.position;
		pos.x = trans.position.x + trans.rigidbody2D.velocity.normalized.x*sight_dist;
		pos.y = trans.position.y + trans.rigidbody2D.velocity.normalized.y*sight_dist;
		pos.z = 0;
		this.transform.position = pos;
		//cameraTransform.LookAt(transform);
	}
}
