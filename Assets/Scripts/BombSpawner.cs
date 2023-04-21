using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
	public Transform[] spawnPoints;

	public float minDelay = .1f;
	public float maxDelay = 1f;


	public GameObject bomb;
	public float maxPos = 1.7f;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(SpawnFruits());
	}

	IEnumerator SpawnFruits()
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];


			Vector2 coinPos = new Vector2(Random.Range(-5f, 5f), -5f);
			spawnIndex = Random.Range(0, 4);
			Instantiate(bomb, coinPos, transform.rotation);
			bomb.hideFlags = HideFlags.HideInHierarchy;

		}

	}
}
