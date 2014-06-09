using UnityEngine;
using System.Collections;

public class RotatingShooter : MonoBehaviour {

	private Quaternion rotation = Quaternion.identity;

	// Update is called once per frame
	void Update () 
	{
		// Ger en slumpad riktning.
		rotation.eulerAngles = new Vector3 (0.0f, 0.0f, Random.Range (-90.0f, 90.0f));
		transform.rotation = rotation;
	}
}
