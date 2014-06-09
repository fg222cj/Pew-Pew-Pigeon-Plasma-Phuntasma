using UnityEngine;
using System.Collections;

public class PatternBoss : Pattern {

	public float startWait;


	void Update () 
	{
		if (PositionY <= 4)
		{
			VerticalSpeed = 0;
		}
	}

}
