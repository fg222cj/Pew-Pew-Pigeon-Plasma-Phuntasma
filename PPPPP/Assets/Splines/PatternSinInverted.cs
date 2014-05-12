using UnityEngine;
using System.Collections;

public class PatternSinInverted : Pattern {

	void Update () 
	{
		HorizontalSpeed = Mathf.Sin (rigidbody.position.y / 3) * 3;
	}
}
