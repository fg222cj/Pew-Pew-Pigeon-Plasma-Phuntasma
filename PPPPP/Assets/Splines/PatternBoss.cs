using UnityEngine;
using System.Collections;

public class PatternBoss : Pattern {

	void Update () 
	{
		if (PositionY <= 4)
		{
			VerticalSpeed = 0;
		}
	}
}
