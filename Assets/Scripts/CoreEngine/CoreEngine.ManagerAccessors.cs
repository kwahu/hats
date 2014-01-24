using UnityEngine;
using System.Collections;

// namassa 16.12.2013
// The Core of the app engine
// In setup partial class all definition of managers should be placed
public partial class CoreEngine : MonoBehaviour 
{
	//
	private static CoreSound _coreSound;
	public static CoreSound CoreSound { 
		get
		{
			if(_coreSound == null)
				_coreSound = new CoreSound();
			return _coreSound;
		}
	}
	
	//
	private static CoreEvent _coreEvent;
	public static CoreEvent CoreEvent { 
		get
		{
			if(_coreEvent == null)
				_coreEvent = new CoreEvent();
			return _coreEvent;
		}
	}
	
	//
	private static CoreData _coreData;
	public static CoreData CoreData { 
		get
		{
			if(_coreData == null)
				_coreData = new CoreData();
			return _coreData;
		}
	}

	//
	private static CoreScene _coreScene;
	public static CoreScene CoreScene { 
		get
		{
			if(_coreScene == null)
				_coreScene = new CoreScene();
			return _coreScene;
		}
	}
}
