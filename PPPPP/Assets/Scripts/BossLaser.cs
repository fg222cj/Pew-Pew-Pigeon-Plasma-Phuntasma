using UnityEngine;
using System.Collections;

public class BossLaser : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void FixedUpdate () 
	{
		rigidbody.velocity = transform.TransformDirection (Vector3.down * speed);
	}
}
