using UnityEngine;
using System.Collections;

public class SpriteOrdering : MonoBehaviour
{
		Transform _playerTransform;
		Transform _transform;
		Renderer _renderer;
		float center;

		void Start ()
		{
				_playerTransform = GameObject.Find ("Player").transform;
				_transform = this.transform;
				_renderer = this.renderer;
				if (this.GetComponent<BoxCollider2D> ())
						center = this.GetComponent<BoxCollider2D> ().center.y;
				else
						center = this.GetComponent<CircleCollider2D> ().center.y;
		}

		void Update ()
		{
				if (_playerTransform.position.y < (_transform.position.y + center))
						_renderer.sortingLayerName = "Background";
				else
						_renderer.sortingLayerName = "Foreground";
		}
}
