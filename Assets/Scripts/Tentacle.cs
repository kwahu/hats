using UnityEngine;
using System.Collections;

public class Tentacle : MonoBehaviour {

	public bool left;

	void OnTriggerEnter2D(Collider2D coll)
	{
		this.transform.parent.GetComponent<enemy_playground>().adjusting = true;
		if(left)
			this.transform.parent.GetComponent<enemy_playground>().adjustLeft = true;
		else
			this.transform.parent.GetComponent<enemy_playground>().adjustRight = true;
	}

}
