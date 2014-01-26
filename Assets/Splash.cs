using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{

		private Renderer _renderer;
		private Material _splashMaterial;
		private Color _splashTint = Color.white;
		private float _time = -1f;
		public bool appear = false;
		
		void Start ()
		{
				_renderer = renderer;
			
				_splashMaterial = new Material (_renderer.sharedMaterial);
				_renderer.material = _splashMaterial;

				if (appear) {
						_splashTint.a = 0;
						_splashMaterial.color = _splashTint;
				} else {
						_splashTint.a = 1;
						_splashMaterial.color = _splashTint;
				}
		}

		void Update ()
		{
				_time += Time.deltaTime;
				if (_time > 0)
				if (appear) {
						_splashTint.a = Mathf.Lerp (0.0f, 1.0f, _time);
				} else {
						_splashTint.a = Mathf.Lerp (1.0f, 0.0f, _time);
				}
				_splashMaterial.color = _splashTint;
		}
}
