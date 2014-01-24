using UnityEngine;
using System.Collections;

// namassa 15.12.2013
// input zone
public partial class CoreInputZone : MonoBehaviour
{
	//
	void UpdateMouse()
	{
		if(Input.GetMouseButtonUp(0) == true)
			InputRelease();
	}
}

