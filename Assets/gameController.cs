using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour
{

		public enum Theme
		{
				PLAYGROUND,
				WESTERN,
				PLANES,
				NOIR,
		}

		public Theme currentTheme;
		GameObject player;

	public int targets = 10;
	public bool hatFound;

		void Start ()
		{
				currentTheme = Theme.PLAYGROUND;
				player = GameObject.Find ("Player");
				hatFound = false;
		}
	
		public void ChangeTheme (string newTheme)
		{
		
				switch (newTheme) {
				case "noir":
						currentTheme = Theme.NOIR;
						break;
				case "playground":
						currentTheme = Theme.PLAYGROUND;
						break;
				case "western":
						currentTheme = Theme.WESTERN;
						break;
				case "planes":
						currentTheme = Theme.PLANES;
						break;
				}
		}

		void Update ()
		{
				switch (currentTheme) {
				case Theme.NOIR:
						Noir ();
						break;
				case Theme.PLAYGROUND:
						Playground ();
						break;
				case Theme.WESTERN:
						Western ();
						break;
				case Theme.PLANES:
						Planes ();
						break;
				}
		}

		void Noir ()
		{

		}

		void Playground ()
		{
		if(westernHatFound)
		{
			Application.LoadLevel("west");
		}
		}

		void Western ()
	{		
		if(targets == 0 && planesHatFound)
		{
			Application.LoadLevel("noir");
		}

		}

		void Planes ()
		{
		if(targets == 0)
		{
			Application.LoadLevel("noir");
		}
		}

}
