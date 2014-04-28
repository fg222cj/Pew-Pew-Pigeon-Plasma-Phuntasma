using UnityEngine;
using System.Collections;

public class Pattern : MonoBehaviour {
	protected float VerticalSpeed 
	{ 
		get { return gameObject.rigidbody.velocity.y; }
		set { rigidbody.velocity.y = value; }
	}
	protected float HorizontalSpeed 
	{
		get { return gameObject.rigidbody.velocity.x; }
		set { rigidbody.velocity.x = value; }
	}

	protected float PositionX
	{
		get
		{
			return gameObject.transform.position.x;
		}
	}

	protected float PositionY
	{
		get
		{
			return gameObject.transform.position.y;
		}
	}
}
