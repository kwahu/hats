using UnityEngine;
using System.Collections;

// namassa 16.12.2013
//
public partial class CoreScene : ICoreManager
{
	//
	public enum ESceneType
	{
		INIT,
		MENU,
	}

	//
	public string GetSceneName(ESceneType sceneType)
	{
		switch(sceneType)
		{
		case ESceneType.INIT:
			return string.Empty;

		case ESceneType.MENU:
			return "002_Menu";

		default:
			return string.Empty;
		}
	}
}
