using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private float scale;
	private int maxPlayerHealth;
	private int currentPlayerHealth;
	private GameObject player;
	// Use this for initialization
	void Start () {
		scale = gameObject.transform.localScale.x;
		player = GameObject.Find ("Player");
		maxPlayerHealth = player.GetComponent<PlayerController> ().healthPoints;
		currentPlayerHealth = player.GetComponent<PlayerController> ().healthPoints;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) 
		{
			currentPlayerHealth = player.GetComponent<PlayerController> ().healthPoints;
			gameObject.transform.localScale = new Vector3 (((int)scale / maxPlayerHealth) * currentPlayerHealth, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
		}
		else
		{
			gameObject.transform.localScale = new Vector3 (0f, 0f, 0f);
		}
	}
}
