using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax; // De gränser som spelaren tvingas hålla sig innanför.

}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject laserLeft;
	public GameObject laserRight;
	public Transform laserSpawnLeft;
	public Transform laserSpawnRight;
	public float fireRate;

	public int healthPoints;
	public float invulnerableTime;
	private float invulnerableExpire = 0.0f;

	private float nextFire = 0.0f;

	private Animator anim; // Används till t.ex. skadeanimation.

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (laserLeft, laserSpawnLeft.position, laserSpawnLeft.rotation);
			Instantiate (laserRight, laserSpawnRight.position, laserSpawnRight.rotation);
		}
	}

	void FixedUpdate()
	{
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");


		Vector3 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidbody.velocity = movement * speed;

		// Begränsa spelaren till spelytan.
		rigidbody.position = new Vector2 
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax)
		);

		// Vrid på spelaren när vi flyger i sidled.
		rigidbody.rotation = Quaternion.Euler (0.0f, rigidbody.velocity.x * -tilt, 0.0f);
	}

	// Ta skada och bli tillfälligt oskadbar när vi träffas av en fiende.
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy" && Time.time > invulnerableExpire) 
		{
			invulnerableExpire = Time.time + invulnerableTime;
			anim.SetTrigger("Player Hurt");
			UpdateHealth (-1);
		}
	}

	// Höjer eller sänker spelarens hälsa med amount.
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
		GameObject.Find ("Main Camera").GetComponent<PauseMenu> ().PauseGame ();
	}
}
