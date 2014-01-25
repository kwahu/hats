using UnityEngine;
using System.Collections;

public class Hat : MonoBehaviour {

	public string hatTheme;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Camera.main.GetComponent<gameController>().ChangeTheme(hatTheme);

			Destroy(this.gameObject);
		}
	}
}
