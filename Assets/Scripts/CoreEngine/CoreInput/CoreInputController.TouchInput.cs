using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// namassa 15.12.2013
// main input controller
public partial class CoreInputController: MonoBehaviour
{
	//
	void TouchInputHandler()
	{	
		if(Input.touchCount == 0)
			return;
		
		Touch touch = Input.GetTouch(0);	
				
		EInputPhase phase = 	GetTouchInputPhase(touch);
	
		RaycastTouchInput(touch, phase);
	}
	
	//
	private EInputPhase GetTouchInputPhase(Touch touch)
	{
		switch (touch.phase) 
		{
		case TouchPhase.Began:
			return EInputPhase.BEGIN;
		
		case TouchPhase.Stationary:
			return EInputPhase.STAY;
		
		case TouchPhase.Moved:
			return EInputPhase.STAY;
		
		case TouchPhase.Ended:
			return EInputPhase.END;
			
		case TouchPhase.Canceled:
			return EInputPhase.END;
		}
		
		return EInputPhase.NONE;
	}
	
	//
	private void RaycastTouchInput(Touch touch, EInputPhase phase)
	{
		RaycastHit hit = new RaycastHit ();
		Ray ray ;
		
		ray = _mainCamera.ScreenPointToRay (touch.position);
		
		if(Physics.Raycast (ray, out hit, mask) )
		{
			CoreInputZone zone = hit.collider.GetComponent(typeof(CoreInputZone)) as CoreInputZone;
			
			if(zone == null)
				return;
			
			zone.CurrentTouch = touch;
		
			HandleTouchZone(zone, zone.InputPos, phase);
		}
	}
}
