using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour {

	public float speed;
	public float stopPosition;
	// Use this for initialization
	void Start () {
		rigidbody.velocity = new Vector3(0.0f, speed, 0.0f);
	}

	void Update()
	{
		if (rigidbody.position.y <= stopPosition) 
		{
			rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
		}
	}
}
