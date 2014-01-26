using UnityEngine;
using System.Collections;

public class SpriteOrdering : MonoBehaviour {

	Transform player;
	Transform trans;
	Renderer rend;

	void Start () {
		player = GameObject.Find("Player").transform;
		trans = this.transform;
		rend = this.renderer;
	}
	
	// Update is called once per frame
	void Update () {

		if(player.position.y < trans.position.y) rend.sortingLayerName = "Background";
		else rend.sortingLayerName = "Foreground";
	}
}
