using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour {

	public float speed;
	public float stopPosition;

	// Use this for initialization
	void Start () {
		// Ger bakgrunden en satt hastighet.
		rigidbody.velocity = new Vector3(0.0f, speed, 0.0f);
	}

	void Update()
	{
		// Om vi nått slutet på bakgrunden så slutar den rulla.
		if (rigidbody.position.y <= stopPosition) 
		{
			rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
		}
	}
}
