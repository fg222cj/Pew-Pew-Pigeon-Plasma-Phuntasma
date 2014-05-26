using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int healthPoints;
	public GameObject explosion;
	public int scoreValue;

	private GameController gameController;
	private GameObject gameControllerObject;

	void Start()
	{
		gameControllerObject = GameObject.Find ("Game Controller");
		gameController = gameControllerObject.GetComponent<GameController> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Shot") 
		{
			Instantiate (explosion, gameObject.transform.position, Quaternion.identity);
			UpdateHealth (-1);
			Destroy (other.gameObject);
		}
	}

	public void UpdateHealth(int amount)
	{
		healthPoints = healthPoints + amount;
		if (healthPoints <= 0) 
		{
			Die ();
		}
	}

	void Die()
	{
		Destroy (gameObject);
		gameController.UpdateScore (scoreValue);
	}
}
