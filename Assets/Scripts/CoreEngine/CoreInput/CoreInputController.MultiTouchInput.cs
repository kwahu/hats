using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// namassa 15.12.2013
// main input controller
public partial class CoreInputController: MonoBehaviour
{
	// TODO ALL
	void HandleMultiTouchInput()
	{	
	
		
		/*  MULTITOUCH CRAP
		for (int i = 0; i < Input.touchCount; ++i) {
			Touch t = Input.GetTouch (i);
			
			switch (t.phase) {
			case TouchPhase.Began:
				ray = camera.ScreenPointToRay (t.position);
				if (Physics.Raycast (ray, out hit)) {
					hit.transform.gameObject.SendMessage ("OnTouchBegin", t, SendMessageOptions.DontRequireReceiver);
				}
				break;
			
			case TouchPhase.Stationary:
				ray = camera.ScreenPointToRay (t.position);
				if (Physics.Raycast (ray, out hit)) {
					hit.transform.gameObject.SendMessage ("OnTouchStay", t, SendMessageOptions.DontRequireReceiver);
				}
				break;
			
			case TouchPhase.Moved:
				ray = camera.ScreenPointToRay (t.position);
				if (Physics.Raycast (ray, out hit)) {
					hit.transform.gameObject.SendMessage ("OnTouchStay", t, SendMessageOptions.DontRequireReceiver);
				}
				break;
			
			case TouchPhase.Ended:
				ray = camera.ScreenPointToRay (t.position);
				if (Physics.Raycast (ray, out hit)) {
					hit.transform.gameObject.SendMessage ("OnTouchEnd", t, SendMessageOptions.DontRequireReceiver);
				}
				break;
			
			case TouchPhase.Canceled:
				ray = camera.ScreenPointToRay (t.position);
				if (Physics.Raycast (ray, out hit)) {
					hit.transform.gameObject.SendMessage ("OnTouchEnd", t, SendMessageOptions.DontRequireReceiver);
				}
				break;
			}
		}
		*/
	}
}
