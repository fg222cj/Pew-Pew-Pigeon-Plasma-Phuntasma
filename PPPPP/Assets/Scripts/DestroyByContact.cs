using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") 
		{
			return;
		}

		if (other.tag != "Player") 
		{
			Destroy (other.gameObject);
		}

		Destroy (gameObject);
	}
}
