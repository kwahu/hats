using UnityEngine;
using System.Collections;

public class TextureScroll : MonoBehaviour {

	public Vector2 moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.renderer.material.mainTextureOffset += moveSpeed / 100 * Time.deltaTime;
	}
}
