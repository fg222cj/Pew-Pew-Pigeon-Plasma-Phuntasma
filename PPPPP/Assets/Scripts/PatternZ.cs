using UnityEngine;
using System.Collections;

public class PatternZ : Pattern {

	void Update () 
	{
		if (PositionY <= 3 && PositionX > 1)
		{
			VerticalSpeed = 0;
			HorizontalSpeed = -5;
		}
		else if (PositionY <= 3 && PositionX < -1)
		{
			VerticalSpeed = -5;
			HorizontalSpeed = 0;
		}
	}
}
