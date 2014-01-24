using UnityEngine;
using System.Collections;

// namasssa 16.12.2013
// all IO and XML, JSON serialization and deserialization goes from here
public partial class CoreData : ICoreManager
{
	public enum EAssetType_Sound
	{
		NONE,
	}

	public string GetAssetType_SoundPath(EAssetType_Sound type)
	{
		return "";
	}
}
