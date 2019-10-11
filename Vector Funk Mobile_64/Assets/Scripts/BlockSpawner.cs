using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject blockPrefab;
	public float timeToSpawn = 2f;
	public float timeBetweenWaves = 1f;
	public GameObject pointCollector;
	public GameObject smallBlock;
	public GameObject railPrefab;
	public GameObject shieldPowerUp;
	public GameObject jumpPowerUp;
	public GameObject railTop;
	//public int randomIndex;

	void start(){
	}

	// Use this for initialization

	void Update () {

		if(Time.time>=timeToSpawn)
		{
			SpawnBlocks ();
			timeToSpawn = Time.time + timeBetweenWaves;
		}
	}

	void SpawnBlocks () {

		int randomIndex = Random.Range (0, spawnPoints.Length);
//		for(int n = 0; n<randomEmpty; n++){
//			randomIndex = Random.Range (0, spawnPoints.Length);
//		}
		for (int i = 0; i<spawnPoints.Length;i++)
		{
			if (randomIndex != i) {
				int randomBlock = Random.Range (0, 10);
				switch (randomBlock) {

				case 1:
					Instantiate (blockPrefab, spawnPoints [i].position, Quaternion.identity);
					break;
				case 2:
					Instantiate (railPrefab, spawnPoints [i].position, Quaternion.identity);
					break;
				case 3:
					int freeOrNot = Random.Range (0, 3);
					switch (freeOrNot) {
					case 1:
						break;
					default:
						Instantiate (blockPrefab, spawnPoints [i].position, Quaternion.identity);
						break;
					} 
					break;
				case 4:
					Instantiate (smallBlock, spawnPoints [i].position, Quaternion.identity);
					break;
				default:
					Instantiate (blockPrefab, spawnPoints [i].position, Quaternion.identity);
					break;

				}
			}
			if (randomIndex == i) 
				{
					int randomFree = Random.Range (0, 5);
					switch (randomFree) {
					case 1:
						Instantiate (smallBlock, spawnPoints [i].position, Quaternion.identity);
						break;
				case 2:
					int randomPowerup = Random.Range (0,10);
						switch (randomPowerup){
						case 2:
							Instantiate (jumpPowerUp, spawnPoints [i].position+(new Vector3 (0,.5f,0)), Quaternion.identity);
							break;
						default:
							break;
							}
						break;
					default:
						break;
						}
				
			}
			/*if (randomIndex==i)
			{
				Instantiate (pointCollector,spawnPoints[i].position,Quaternion.identity);
			}*/
		}

	}
	
	// Update is called once per frame

}
