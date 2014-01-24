using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// namassa 16.12.2013
// The Core of the app engine
public partial class CoreEngine : MonoBehaviour 
{
	//
	void ConstructManagers()
	{
		_coreData =  new CoreData();

		_coreSound = new CoreSound();

		_coreEvent =  new CoreEvent();

		_coreScene = new CoreScene();
	}

	//
	void Initialize()
	{
		// 1st on the list, initialize data from files etc
		_coreData.Initialize();

		//
		_coreSound.Initialize();
		_coreEvent.Initialize();
		_coreScene.Initialize();
	}
}
