using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
	public int columns = 20;
	public int rows = 50;
	public GameObject player1base;
	public GameObject player2base;
	public GameObject grassTile;
	public GameObject rockTile;
	public GameObject powerTile;
	public GameObject resourceTile;
	public GameObject enemyUnitTile;
	public GameObject waterTile;

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

	public GameObject PassObject (int x, int y) {
		return null;
	}

	void BoardSetup () {
		boardHolder = new GameObject ("Board").transform;

		for (int x = -1; x < columns + 1; x++) {
			for (int y = -1; y < rows + 1; y++) {
				GameObject toInstantiate = grassTile;
				if (x == -1 || x == columns || y == -1 || y == rows)
					toInstantiate = waterTile;

				GameObject instance = Instantiate(toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;

				instance.transform.SetParent(boardHolder);
			}
		}
	}

	public void SetupScene () {
		BoardSetup ();
		InitializeList ();
		Instantiate (player1base, new Vector3 ((columns / 2) + 1, 0, 0F), Quaternion.identity);
		Instantiate (player1base, new Vector3 ((columns / 2) - 1, 0, 0F), Quaternion.identity);
		Instantiate (player1base, new Vector3 ((columns / 2) - 2, 0, 0F), Quaternion.identity);
		Instantiate (player1base, new Vector3 ((columns / 2), 0, 0F), Quaternion.identity);
		Instantiate (player1base, new Vector3 ((columns / 2) - 1, 1, 0F), Quaternion.identity);
		Instantiate (player1base, new Vector3 ((columns / 2) - 2, 1, 0F), Quaternion.identity);
		Instantiate (player1base, new Vector3 ((columns / 2) + 1, 1, 0F), Quaternion.identity);
		Instantiate (player1base, new Vector3 ((columns / 2), 1, 0F), Quaternion.identity);
		Instantiate (player2base, new Vector3 (columns / 2, rows - 1, 0F), Quaternion.identity);
		Instantiate (player2base, new Vector3 ((columns / 2) + 1, rows - 1, 0F), Quaternion.identity);
		Instantiate (player2base, new Vector3 ((columns / 2) - 1, rows - 1, 0F), Quaternion.identity);
		Instantiate (player2base, new Vector3 ((columns / 2) - 2, rows - 1, 0F), Quaternion.identity);
		Instantiate (player2base, new Vector3 (columns / 2, rows - 2, 0F), Quaternion.identity);
		Instantiate (player2base, new Vector3 ((columns / 2) - 1, rows - 2, 0F), Quaternion.identity);
		Instantiate (player2base, new Vector3 ((columns / 2) + 1, rows - 2, 0F), Quaternion.identity);
		Instantiate (player2base, new Vector3 ((columns / 2) - 2, rows - 2, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 6, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 6, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 5, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 5, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 15, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (9, 17, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (10, 15, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (10, 17, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (9, 16, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 16, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (9, 15, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 17, 0F), Quaternion.identity);
		Instantiate (resourceTile, new Vector3 (10, 16, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (16, 7, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (15, 7, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (14, 8, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (14, 7, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (13, 7, 0F), Quaternion.identity);
		Instantiate (resourceTile, new Vector3 (13, 6, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (15, 43, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (17, 41, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (15, 42, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (17, 42, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (16, 41, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (16, 43, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (15, 41, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (17, 43, 0F), Quaternion.identity);
		Instantiate (resourceTile, new Vector3 (16, 42, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (9, 25, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (10, 25, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (10, 26, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (10, 27, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (10, 28, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 26, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 27, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (12, 26, 0F), Quaternion.identity);
		Instantiate (resourceTile, new Vector3 (18, 21, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (19, 21, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (19, 22, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (19, 20, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (19, 19, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (19, 18, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (18, 20, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (18, 19, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (17, 19, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (17, 20, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (16, 20, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (17, 8, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 7, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (5, 7, 0F), Quaternion.identity);
		Instantiate (resourceTile, new Vector3 (3, 7, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 23, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 24, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 25, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 26, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 27, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 28, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 29, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 30, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 31, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 32, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 33, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 34, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (0, 35, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (1, 24, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (1, 25, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (1, 26, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (1, 27, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (1, 28, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (1, 29, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (1, 30, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (1, 31, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (1, 33, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (1, 34, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 25, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 26, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 27, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 28, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 29, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 30, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 31, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 32, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 33, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 26, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 28, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 29, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 30, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 31, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 32, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 27, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 28, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 29, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 30, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 31, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 32, 0F), Quaternion.identity);
		Instantiate (resourceTile, new Vector3 (1, 32, 0F), Quaternion.identity);
		Instantiate (resourceTile, new Vector3 (3, 27, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 43, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (2, 44, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 43, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 44, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 45, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 45, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 45, 0F), Quaternion.identity);
		Instantiate (resourceTile, new Vector3 (1, 43, 0F), Quaternion.identity);
		Instantiate (powerTile, new Vector3 (4, 12, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (5, 11, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 11, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (5, 13, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (3, 13, 0F), Quaternion.identity);
		Instantiate (powerTile, new Vector3 (18, 15, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (19, 14, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (17, 14, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (19, 16, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (17, 16, 0F), Quaternion.identity);
		Instantiate (powerTile, new Vector3 (7, 22, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (7, 23, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (8, 24, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (8, 21, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (6, 21, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (8, 23, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (6, 23, 0F), Quaternion.identity);
		Instantiate (powerTile, new Vector3 (12, 29, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (13, 28, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 28, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (13, 30, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 30, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (9, 23, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (9, 24, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (10, 24, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (10, 29, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 29, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 25, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (8, 22, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (12, 28, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (12, 27, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (10, 37, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (10, 36, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (9, 37, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 37, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (11, 39, 0F), Quaternion.identity);
		Instantiate (resourceTile, new Vector3 (11, 38, 0F), Quaternion.identity);
		Instantiate (powerTile, new Vector3 (17, 35, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (18, 34, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (16, 34, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (18, 36, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (16, 36, 0F), Quaternion.identity);
		Instantiate (powerTile, new Vector3 (5, 39, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (6, 38, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 38, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (6, 40, 0F), Quaternion.identity);
		Instantiate (rockTile, new Vector3 (4, 40, 0F), Quaternion.identity);
	}
}
