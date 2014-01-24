using UnityEngine;
using System.Collections;

// namassa 16.12.2013
//
public partial class CoreScene : ICoreManager
{
	public ESceneType CurrentScene { get; private set; }

	//
	public override void Initialize ()
	{
		CurrentScene = ESceneType.INIT;
	}

	//
	public void LoadScene(ESceneType sceneType)
	{
		Application.LoadLevel( GetSceneName(sceneType) );
	}
}
