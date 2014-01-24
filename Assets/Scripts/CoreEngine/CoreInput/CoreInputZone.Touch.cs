using UnityEngine;
using System.Collections;

// namassa 15.12.2013
// input zone
public partial class CoreInputZone : MonoBehaviour
{
	//
	void UpdateTouch()
	{
		if(Input.touchCount == 0)
		{
			InputRelease();	
			return;
		}
		
		for (int i = 0; i < Input.touchCount; i++) 
		{
			Touch t = Input.GetTouch (i);
			
			if(t.fingerId == fingerID)
			{
				if(t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
				{
					OnInputEnd(this);	
				}
			}
		}
	}
	
	//
	private void TouchInputBegin(Touch t)
	{
		if(t.fingerId != -1)
		{	
			fingerID = t.fingerId;
		}
		
		InputPos = (Vector3) t.position;
		
		OnInputBegin(this);
	}
	
	//
	private void TouchInputEnd(Touch t)
	{
		if(IsDown == false)
			return;
		
		if(t.fingerId != -1)
		{
			fingerID = -1;
		}
		
		IsDown = false;
		
		OnInputEnd(this);
	}
}

