using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public List<WaveController> waves;

	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public int score;

	void Start()
	{
		StartCoroutine (SpawnWaves ());
	}

	// Spawnar vågor med fiender med godtycklig väntetid emellan.
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds(startWait);

		foreach(WaveController wave in waves) 
		{
			for(int i = 0; i < wave.enemyCount; i++)
			{
				Instantiate (wave.enemy, wave.spawnValues, Quaternion.identity);
				yield return new WaitForSeconds(wave.spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

	public void UpdateScore(int scoreValue)
	{
		score += scoreValue;
		scoreText.text = score.ToString();
	}
}
