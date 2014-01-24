using UnityEngine;
using System.Collections;

// namassa 16.12.2013
// The Core of the app engine
public partial class CoreEngine : MonoBehaviour 
{
	// Singleton
	// Implementation
	static CoreEngine _coreEngine;
	public CoreEngine Instance 
	{
		get
		{
			if(_coreEngine == null)
				_coreEngine = this;
			
			return _coreEngine;
		}
		
		private set
		{
			_coreEngine = value;	
		}
	}
	
	//
	void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(gameObject);

		ConstructManagers();
	}

	// Initalization
	void Start()
	{
		Initialize();
	}
	
	// Engine Loop
	void Update()
	{
		
	}
}
