using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float verticalSpeed;
	public float horizontalSpeed;

	void Start()
	{
		rigidbody.velocity = new Vector3(1 * horizontalSpeed, 1 * verticalSpeed, 0.0f);
	}
}
