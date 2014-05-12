using UnityEngine;
using System.Collections;

public class PatternZInverted : Pattern
{
	void Update () 
	{
		if (PositionY <= -1 && PositionX < -1)
		{
			VerticalSpeed = 2;
			HorizontalSpeed = 4;
		}
		else if (PositionX > 2)
		{
			VerticalSpeed = -4;
			HorizontalSpeed = 0;
		}
	}
}
