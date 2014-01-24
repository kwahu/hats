using UnityEngine;
using System.Collections;

// namassa 17.12.2013
public class SplashScreenController : MonoBehaviour 
{
	//
	[System.Serializable]
	public class SplashScreen
	{
		public Texture SplashTexture;
		public float ShowTime = 2.0f;
	}

	//
	private enum ESplashState
	{
		INIT,
		SHOWING,
		VISIBLE,
		HIDING,
		HIDDEN,
		OFF,
	}

	public float FadeInTime = 1.0f;
	public float FadeOutTime = 1.0f;

	public SplashScreen[] SplashScreenArray;

	// members
	private Renderer _renderer;
	private Material _splashMaterial;
	private Color _splashTint = Color.white;

	private float _time = 0.0f;
	private float _timer = 0.0f;

	private int _currentSplash = 0;
	private ESplashState _splashState = ESplashState.OFF;

	// Use this for initialization
	void Start () 
	{
		_renderer = renderer;

		_splashMaterial = new Material(_renderer.sharedMaterial);
		_renderer.material = _splashMaterial;

		_splashState = ESplashState.INIT;
	}

	void SetSplash(SplashScreen splash)
	{
		_splashTint.a = 0.0f;
		_splashMaterial.color = _splashTint;
		
		_splashMaterial.mainTexture = splash.SplashTexture;
	}
	
	// Update is called once per frame
	void Update () 
	{
		_time += Time.deltaTime;

		switch(_splashState)
		{
		case ESplashState.INIT:

			SetSplash(SplashScreenArray[_currentSplash]);

			_time = 0.0f;
			_timer = FadeInTime;

			_splashState = ESplashState.SHOWING;

			break;

		case ESplashState.SHOWING:

			_splashTint.a = Mathf.Lerp(0.0f,1.0f,_time);
			_splashMaterial.color = _splashTint;

			if(_time >= _timer)
			{
				_time = 0.0f;
				_timer = SplashScreenArray[_currentSplash].ShowTime;
				_splashState = ESplashState.VISIBLE;
			}

			break;

		case ESplashState.VISIBLE:

			if(_time >= _timer)
			{
				_time = 0.0f;
				_timer = FadeOutTime;
				_splashState = ESplashState.HIDING;
			}

			break;

		case ESplashState.HIDING:

			_splashTint.a = Mathf.Lerp(1.0f,0.0f,_time);
			_splashMaterial.color = _splashTint;
			
			if(_time >= _timer)
			{
				_time = 0.0f;
				_splashState = ESplashState.HIDDEN;
			}

			break;

		case ESplashState.HIDDEN:

			if( (SplashScreenArray.Length -1) > _currentSplash)
			{
				_currentSplash++;
				_splashState = ESplashState.INIT;
			}
			else
			{
				_splashState = ESplashState.OFF;
			}

			break;

		case ESplashState.OFF:

			CoreEngine.CoreScene.LoadScene(CoreScene.ESceneType.MENU);

			break;
		}
	}
}
