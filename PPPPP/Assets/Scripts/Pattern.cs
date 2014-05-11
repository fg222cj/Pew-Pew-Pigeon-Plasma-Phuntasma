using UnityEngine;
using System.Collections;

public class Pattern : MonoBehaviour {
	public float VerticalSpeed
	{ 
		get { return gameObject.rigidbody.velocity.y; }
		set { gameObject.rigidbody.velocity = new Vector3(HorizontalSpeed, value, 0.0f); }
	}
	public float HorizontalSpeed
	{
		get { return gameObject.rigidbody.velocity.x; }
		set { gameObject.rigidbody.velocity = new Vector3(value, VerticalSpeed, 0.0f); }
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
