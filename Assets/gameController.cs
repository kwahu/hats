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

		void Start ()
		{
				currentTheme = Theme.PLAYGROUND;
		player = GameObject.Find("Player");
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

		//	player.GetComponent<Animator>().runtimeAnimatorController
		}	

}
