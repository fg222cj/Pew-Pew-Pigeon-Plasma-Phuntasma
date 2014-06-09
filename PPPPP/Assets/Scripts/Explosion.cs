using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	
	void Start () 
	{
		// Destroy() måste fördröjas lite, därav Invoke.
		Invoke ("Die", 0.1f);
	}

	void Die()
	{
		Destroy (gameObject);
	}
}
