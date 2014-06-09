using UnityEngine;
using System.Collections;

public class Boss : Enemy 
{
	public Transform laserSpawnRotating;
	public Transform laserSpawn1;
	public Transform laserSpawn2;
	public Transform laserSpawn3;
	public Transform laserSpawn4;
	public Transform laserSpawn5;
	public GameObject laser;
	public float fireRateRotating;
	public float fireRateFixed;
	public int rotatingShots;
	public float shotWait;

	private float nextFireFixed = Time.time + 2;
	private float nextFireRotating = Time.time + 5;
	
	// Update is called once per frame
	void Update () 
	{
		// Kollar om det är dags att skjuta och gör i så fall det.
		if(nextFireFixed < Time.time)
		{
			Instantiate(laser, laserSpawn1.position, laserSpawn1.rotation);
			Instantiate(laser, laserSpawn2.position, laserSpawn2.rotation);
			Instantiate(laser, laserSpawn3.position, laserSpawn3.rotation);
			Instantiate(laser, laserSpawn4.position, laserSpawn4.rotation);
			Instantiate(laser, laserSpawn5.position, laserSpawn5.rotation);
			nextFireFixed = Time.time + fireRateFixed;
		}

		// Kollar om det är dags att skjuta och gör i så fall det.
		if(nextFireRotating < Time.time)
		{
			StartCoroutine(FireRotator());
			nextFireRotating = Time.time + fireRateRotating;
		}

	}

	// Avfyrar slumpmässigt riktade salvor. Se RotatingShooter.cs.
	IEnumerator FireRotator()
	{
		for(int shotsFired = 0; shotsFired < rotatingShots; shotsFired++)
		{
			Instantiate(laser, laserSpawnRotating.position, laserSpawnRotating.rotation);
			yield return new WaitForSeconds(shotWait);
		}
	}
}
