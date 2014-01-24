using UnityEngine;
using System.Collections;

// namassa 15.12.2013
// input zone
public partial class CoreInputZone : MonoBehaviour
{
	//
	void OnDrawGizmos()
	{
		Color s = Color.red;
		s.a = 0.1f;
		Color r = Color.blue;
		r.a = 0.1f;
		
		Gizmos.matrix = transform.localToWorldMatrix;
		
		Collider c = collider;
		
		if( c.GetType() == typeof(BoxCollider))
		{
			if(IsDown)
				Gizmos.color = Color.red;
			else
				Gizmos.color = Color.blue;
			
			BoxCollider cb = (BoxCollider)c;
			
			Gizmos.DrawWireCube(cb.center, cb.extents*2);	
			
			if(IsDown)
				Gizmos.color = s;
			else
				Gizmos.color = r;
			
			Gizmos.DrawCube(cb.center, cb.extents*2);
		}
		
		if( c.GetType() == typeof(SphereCollider))
		{
			if(IsDown)
				Gizmos.color = Color.red;
			else
				Gizmos.color = Color.blue;
			
			SphereCollider cs = (SphereCollider)c;
			
			Gizmos.DrawWireSphere(cs.center, cs.radius);	
			
			if(IsDown)
				Gizmos.color = s;
			else
				Gizmos.color = r;
			
			Gizmos.DrawSphere(cs.center, cs.radius);	
		}
	}
}

