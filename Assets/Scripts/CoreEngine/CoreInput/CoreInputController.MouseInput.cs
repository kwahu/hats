using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// namassa 15.12.2013
// main input controller
public partial class CoreInputController: MonoBehaviour
{
	//
	private void MouseInputHandler()
	{
		EInputPhase inputPhase = GetMouseInputPhase();
		
		if(inputPhase != EInputPhase.NONE)
			RaycastMouseInput(inputPhase);
	}
	
	//
	private EInputPhase GetMouseInputPhase()
	{
		if(Input.GetMouseButtonDown(0) == true)
			return EInputPhase.BEGIN;
		
		if(Input.GetMouseButtonDown(0) == false && Input.GetMouseButton(0) == true)
			return EInputPhase.STAY;
		
		if(Input.GetMouseButtonUp(0) == true)
			return EInputPhase.END;
		
		return EInputPhase.NONE;
	}
	
	//
	private void RaycastMouseInput(EInputPhase phase)
	{
		RaycastHit hit = new RaycastHit ();
		Ray ray ;
		
		ray = _mainCamera.ScreenPointToRay (Input.mousePosition);
			
		if(Physics.Raycast (ray, out hit, 1000, mask) )
		{
			CoreInputZone zone = hit.collider.GetComponent(typeof(CoreInputZone)) as CoreInputZone;
			
			if(zone == null)
				return;
		
			HandleTouchZone(zone, (Vector3)Input.mousePosition, phase);
		}
	}
}
