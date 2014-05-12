using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public List<WaveController> waves;

	public float startWait;
	public float waveWait;

	public float restartWait; // Antal sekunder tills allt börjar om. Ta bort den här när nivåer har implementerats.

	void Start()
	{
		StartCoroutine (SpawnWaves ());
	}
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			foreach(WaveController wave in waves) 
			{
				for(int i = 0; i < wave.enemyCount; i++)
				{
					Instantiate (wave.enemy, wave.spawnValues, Quaternion.identity);
					yield return new WaitForSeconds(wave.spawnWait);
				}
				yield return new WaitForSeconds(waveWait);
			}
			yield return new WaitForSeconds(restartWait);
		}
	}
}
