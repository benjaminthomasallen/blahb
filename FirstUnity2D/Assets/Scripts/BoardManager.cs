using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
	[Serializable]
	public class Count {
		public int minimum;
		public int maximum;

		public Count (int min, int max) {
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 8;
	public int rows = 8;
	public Count rockCount = new Count (3, 4);
	public Count powerCount = new Count (3, 3);
	public Count resourceCount = new Count (3, 3);
	public GameObject player1base;
	public GameObject player2base;
	public GameObject[] grassTiles;
	public GameObject[] rockTiles;
	public GameObject[] powerTiles;
	public GameObject[] resourceTiles;
	public GameObject[] enemyUnitTiles;
	public GameObject[] waterTiles;

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List<Vector3>();

	void InitializeList () {
		gridPositions.Clear();

		for (int x = 1; x < columns - 1; x++) {
			for (int y = 1; y < rows - 1; y++) {
				gridPositions.Add(new Vector3(x, y, 0f));
			}
		}
	}

	void BoardSetup () {
		boardHolder = new GameObject ("Board").transform;

		for (int x = -1; x < columns + 1; x++) {
			for (int y = -1; y < rows + 1; y++) {
				GameObject toInstantiate = grassTiles[Random.Range(0, grassTiles.Length)];
				if (x == -1 || x == columns || y == -1 || y == rows)
					toInstantiate = waterTiles[Random.Range(0, waterTiles.Length)];

				GameObject instance = Instantiate(toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;

				instance.transform.SetParent(boardHolder);
			}
		}
	}

	Vector3 RandomPosition () {
		int randomIndex = Random.Range(0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt(randomIndex);
		return randomPosition;
	}

	void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum) {
		int objectCount = Random.Range (minimum, maximum + 1);

		for (int i = 0; i < objectCount; i++) {
			Vector3 randomPosition = RandomPosition ();
			GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];
			Instantiate (tileChoice, randomPosition, Quaternion.identity);
		}
	}

	public void SetupScene () {
		BoardSetup ();
		InitializeList ();
		LayoutObjectAtRandom (rockTiles, rockCount.minimum, rockCount.maximum);
		LayoutObjectAtRandom (powerTiles, powerCount.minimum, powerCount.maximum);
		LayoutObjectAtRandom (resourceTiles, resourceCount.minimum, resourceCount.maximum);
		LayoutObjectAtRandom (enemyUnitTiles, 1, 3);
		Instantiate (player1base, new Vector3 ((columns / 2) - 1, 0, 0F), Quaternion.identity);
		Instantiate (player2base, new Vector3 (columns / 2, rows - 1, 0F), Quaternion.identity);
	}
}
