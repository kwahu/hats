using UnityEngine;
using System.Collections;

// namassa 15.12.2013
// input zone
public partial class CoreInputZone : MonoBehaviour
{
	//
	public delegate void InputEventDelegate(CoreInputZone z);
	public InputEventDelegate OnInputBegin = delegate {};
	public InputEventDelegate OnInputStay = delegate {};
	public InputEventDelegate OnInputEnd = delegate {};

	// members
	private Vector3 _inputPos;
	public Vector3 InputPos { 
		get { return _inputPos; }
		set { _inputPos = value; }
	}
	
	private Touch _touch;
	public Touch CurrentTouch { 
		private get{ return _touch;} 
		set { _touch = value; }
	}

	int fingerID = -1;
	
	public bool IsDown { get; private set; }
	
	//
	void Update()
	{
		if(IsDown == false)
			return;
		
#if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR
		UpdateTouch();
#else
		UpdateMouse();
#endif
	}
	
	//
	private void InputRelease()
	{
		IsDown = false;
		
		OnInputEnd(this);
	}
	
	//
	public void InputBegin()
	{
		IsDown = true;
#if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR
		TouchInputBegin();
#else
		OnInputBegin(this);
#endif
	}
	
	public void InputStay()
	{
		IsDown = true;
		
#if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR
		UpdateTouch(CurrentTouch);
#else
		OnInputStay(this);
#endif
	}
	
	//
	public void InputEnd()
	{
		IsDown = false;
		
#if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR
		TouchInputEnd(CurrentTouch);
#else
		OnInputEnd(this);
#endif
	}
}

