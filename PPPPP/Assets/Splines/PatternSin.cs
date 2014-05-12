using UnityEngine;
using System.Collections;

public class PatternSin : Pattern
{
	void Update () 
	{
		HorizontalSpeed = -Mathf.Sin (rigidbody.position.y / 3) * 3;
	}
}
