using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// namassa 15.12.2013
// main input controller
public partial class CoreInputController: MonoBehaviour
{
	//
	public enum EDisplayArea
	{
		NONE,
		IPHONE,
		IPHONE5,
		IPAD,
		OTHER
	};
	
	//  propetries
	public EDisplayArea displayArea = EDisplayArea.NONE;

	//
	void OnDrawGizmos()
	{
		DrawArea(displayArea);
	}
	
	// 
	void DrawArea( EDisplayArea displayArea )
	{
		if(displayArea == EDisplayArea.NONE)
			return;
		
		Vector3 size = Vector3.zero;
		
		switch(displayArea)
		{
		case EDisplayArea.IPAD:
			size.x = 1024;
			size.y = 768;
			break;
			
		case EDisplayArea.IPHONE:
			size.x = 960;
			size.y = 640;
			break;
			
		case EDisplayArea.IPHONE5:
			size.x = 1136;
			size.y = 640;
			break;
		}
		
		size.z = 1000.0f;
		
		Camera cam = _mainCamera;
		
		if(cam == null)
			cam = Camera.mainCamera;
		
		Gizmos.matrix = cam.transform.localToWorldMatrix;
		
		
		float r = cam.orthographicSize;
		
		float pxUnit = r * 2.0f / size.y;
		
		Vector3 newSize = Vector3.zero;
		
		newSize.x = size.x * pxUnit;
		newSize.y = size.y * pxUnit;
		newSize.z = cam.far;
		
		Gizmos.color = Color.white;
		Gizmos.DrawWireCube( Vector3.forward * newSize.z * 0.5f, newSize );
		
		Gizmos.color = Color.red;
		Gizmos.DrawSphere( Vector3.zero, 0.3f);
		Gizmos.DrawLine(Vector3.zero, Vector3.forward);
	}
}
