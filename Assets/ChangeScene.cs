using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public string scene;

	void Update () {
		if(Input.anyKeyDown)
		if(scene != "") Application.LoadLevel(scene);
	}


}
