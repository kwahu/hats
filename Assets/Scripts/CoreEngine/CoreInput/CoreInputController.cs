using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// namassa 15.12.2013
// main input controller
public partial class CoreInputController: MonoBehaviour
{
	//
	private enum EInputPhase
	{
		NONE,
		BEGIN,
		STAY,
		END,
	}
	
	private delegate void InputHandlerDelegate();
	private InputHandlerDelegate InputHandler = delegate{};
	
	// properties
	public LayerMask mask;	
	
	// members
	private Camera _mainCamera;
	
	void Awake()
	{
		if(camera != null)
			_mainCamera = camera;
		else
			_mainCamera = Camera.mainCamera;
		
#if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR
		InputHandler += TouchInputHandler;
#else
		InputHandler += MouseInputHandler;
#endif
	}
	
	//
	void Update ()
	{	
		InputHandler();
	}
	
	//
	private void HandleTouchZone(CoreInputZone zone, Vector3 inputPos, EInputPhase phase)
	{
		zone.InputPos = inputPos;
	
		switch(phase)
		{
		case EInputPhase.BEGIN:
			zone.InputBegin();
			break;
			
		case EInputPhase.STAY:
			zone.InputStay();
			break;
			
		case EInputPhase.END:
			zone.InputEnd();
			break;
		}	
	}
}
