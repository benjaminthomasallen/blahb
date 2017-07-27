using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class PrefabTile {
	public GameObject Ttype;
	public int posX;
	public int posY;

	public PrefabTile(GameObject tile_type, int x, int y) {
		this.Ttype = tile_type;
		this.posX = x;
		this.posY = y;
	}
}

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

	private GameObject[,] boardGrid = new GameObject[20, 50];
	private Transform boardHolder;
	private Queue <PrefabTile> gridPositions = new Queue<PrefabTile>();

	public GameObject PassObject (int x, int y) {
		return boardGrid[x,y];
	}

	void BoardSetup () {
		GameObject tempObject;

		boardHolder = new GameObject ("Board").transform;

		for (int x = -1; x < columns + 1; x++) {
			for (int y = -1; y < rows + 1; y++) {
				if (x == -1 || x == columns || y == -1 || y == rows) {
					tempObject = Instantiate(waterTile, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					tempObject.transform.SetParent(boardHolder);
				}
				else {
					boardGrid[x,y] = Instantiate(grassTile, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					boardGrid[x,y].transform.SetParent(boardHolder);
				}
			}
		}
	}

	public Transform passBoard () {
		return boardHolder;
	}

	private void createTile (PrefabTile prefabricated) {
		Destroy (boardGrid [prefabricated.posX, prefabricated.posY]);
		boardGrid[prefabricated.posX,prefabricated.posY] = Instantiate (prefabricated.Ttype, new Vector3 (prefabricated.posX, prefabricated.posY, 0F), Quaternion.identity) as GameObject;
		boardGrid[prefabricated.posX,prefabricated.posY].transform.SetParent(boardHolder);
	}

	public void SetupScene () {
		BoardSetup ();
		LoadQueue ();

		while (gridPositions.Count > 0) {
			createTile (gridPositions.Dequeue());
		}
	}

	private void LoadQueue () {
		gridPositions.Clear();

		gridPositions.Enqueue (new PrefabTile (player1base, (columns / 2) + 1, 0));
		gridPositions.Enqueue (new PrefabTile (player1base, (columns / 2) - 1, 0));
		gridPositions.Enqueue (new PrefabTile (player1base, (columns / 2) - 2, 0));
		gridPositions.Enqueue (new PrefabTile (player1base, (columns / 2), 0));
		gridPositions.Enqueue (new PrefabTile (player1base, (columns / 2) - 1, 1));
		gridPositions.Enqueue (new PrefabTile (player1base, (columns / 2) - 2, 1));
		gridPositions.Enqueue (new PrefabTile (player1base, (columns / 2) + 1, 1));
		gridPositions.Enqueue (new PrefabTile (player1base, (columns / 2), 1));
		gridPositions.Enqueue (new PrefabTile (player2base, columns / 2, rows - 1));
		gridPositions.Enqueue (new PrefabTile (player2base, (columns / 2) + 1, rows - 1));
		gridPositions.Enqueue (new PrefabTile (player2base, (columns / 2) - 1, rows - 1));
		gridPositions.Enqueue (new PrefabTile (player2base, (columns / 2) - 2, rows - 1));
		gridPositions.Enqueue (new PrefabTile (player2base, columns / 2, rows - 2));
		gridPositions.Enqueue (new PrefabTile (player2base, (columns / 2) - 1, rows - 2));
		gridPositions.Enqueue (new PrefabTile (player2base, (columns / 2) + 1, rows - 2));
		gridPositions.Enqueue (new PrefabTile (player2base, (columns / 2) - 2, rows - 2));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 6));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 6));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 5));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 5));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 15));
		gridPositions.Enqueue (new PrefabTile (rockTile, 9, 17));
		gridPositions.Enqueue (new PrefabTile (rockTile, 10, 15));
		gridPositions.Enqueue (new PrefabTile (rockTile, 10, 17));
		gridPositions.Enqueue (new PrefabTile (rockTile, 9, 16));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 16));
		gridPositions.Enqueue (new PrefabTile (rockTile, 9, 15));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 17));
		gridPositions.Enqueue (new PrefabTile (resourceTile, 10, 16));
		gridPositions.Enqueue (new PrefabTile (rockTile, 16, 7));
		gridPositions.Enqueue (new PrefabTile (rockTile, 15, 7));
		gridPositions.Enqueue (new PrefabTile (rockTile, 14, 8));
		gridPositions.Enqueue (new PrefabTile (rockTile, 14, 7));
		gridPositions.Enqueue (new PrefabTile (rockTile, 13, 7));
		gridPositions.Enqueue (new PrefabTile (resourceTile, 13, 6));
		gridPositions.Enqueue (new PrefabTile (rockTile, 15, 43));
		gridPositions.Enqueue (new PrefabTile (rockTile, 17, 41));
		gridPositions.Enqueue (new PrefabTile (rockTile, 15, 42));
		gridPositions.Enqueue (new PrefabTile (rockTile, 17, 42));
		gridPositions.Enqueue (new PrefabTile (rockTile, 16, 41));
		gridPositions.Enqueue (new PrefabTile (rockTile, 16, 43));
		gridPositions.Enqueue (new PrefabTile (rockTile, 15, 41));
		gridPositions.Enqueue (new PrefabTile (rockTile, 17, 43));
		gridPositions.Enqueue (new PrefabTile (resourceTile, 16, 42));
		gridPositions.Enqueue (new PrefabTile (rockTile, 9, 25));
		gridPositions.Enqueue (new PrefabTile (rockTile, 10, 25));
		gridPositions.Enqueue (new PrefabTile (rockTile, 10, 26));
		gridPositions.Enqueue (new PrefabTile (rockTile, 10, 27));
		gridPositions.Enqueue (new PrefabTile (rockTile, 10, 28));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 26));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 27));
		gridPositions.Enqueue (new PrefabTile (rockTile, 12, 26));
		gridPositions.Enqueue (new PrefabTile (resourceTile, 18, 21));
		gridPositions.Enqueue (new PrefabTile (rockTile, 19, 21));
		gridPositions.Enqueue (new PrefabTile (rockTile, 19, 22));
		gridPositions.Enqueue (new PrefabTile (rockTile, 19, 20));
		gridPositions.Enqueue (new PrefabTile (rockTile, 19, 19));
		gridPositions.Enqueue (new PrefabTile (rockTile, 19, 18));
		gridPositions.Enqueue (new PrefabTile (rockTile, 18, 20));
		gridPositions.Enqueue (new PrefabTile (rockTile, 18, 19));
		gridPositions.Enqueue (new PrefabTile (rockTile, 17, 19));
		gridPositions.Enqueue (new PrefabTile (rockTile, 17, 20));
		gridPositions.Enqueue (new PrefabTile (rockTile, 16, 20));
		gridPositions.Enqueue (new PrefabTile (rockTile, 17, 8));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 7));
		gridPositions.Enqueue (new PrefabTile (rockTile, 5, 7));
		gridPositions.Enqueue (new PrefabTile (resourceTile, 3, 7));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 23));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 24));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 25));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 26));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 27));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 28));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 29));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 30));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 31));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 32));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 33));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 34));
		gridPositions.Enqueue (new PrefabTile (rockTile, 0, 35));
		gridPositions.Enqueue (new PrefabTile (rockTile, 1, 24));
		gridPositions.Enqueue (new PrefabTile (rockTile, 1, 25));
		gridPositions.Enqueue (new PrefabTile (rockTile, 1, 26));
		gridPositions.Enqueue (new PrefabTile (rockTile, 1, 27));
		gridPositions.Enqueue (new PrefabTile (rockTile, 1, 28));
		gridPositions.Enqueue (new PrefabTile (rockTile, 1, 29));
		gridPositions.Enqueue (new PrefabTile (rockTile, 1, 30));
		gridPositions.Enqueue (new PrefabTile (rockTile, 1, 31));
		gridPositions.Enqueue (new PrefabTile (rockTile, 1, 33));
		gridPositions.Enqueue (new PrefabTile (rockTile, 1, 34));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 25));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 26));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 27));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 28));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 29));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 30));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 31));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 32));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 33));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 26));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 28));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 29));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 30));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 31));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 32));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 27));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 28));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 29));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 30));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 31));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 32));
		gridPositions.Enqueue (new PrefabTile (resourceTile, 1, 32));
		gridPositions.Enqueue (new PrefabTile (resourceTile, 3, 27));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 43));
		gridPositions.Enqueue (new PrefabTile (rockTile, 2, 44));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 43));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 44));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 45));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 45));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 45));
		gridPositions.Enqueue (new PrefabTile (resourceTile, 1, 43));
		gridPositions.Enqueue (new PrefabTile (powerTile, 4, 12));
		gridPositions.Enqueue (new PrefabTile (rockTile, 5, 11));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 11));
		gridPositions.Enqueue (new PrefabTile (rockTile, 5, 13));
		gridPositions.Enqueue (new PrefabTile (rockTile, 3, 13));
		gridPositions.Enqueue (new PrefabTile (powerTile, 18, 15));
		gridPositions.Enqueue (new PrefabTile (rockTile, 19, 14));
		gridPositions.Enqueue (new PrefabTile (rockTile, 17, 14));
		gridPositions.Enqueue (new PrefabTile (rockTile, 19, 16));
		gridPositions.Enqueue (new PrefabTile (rockTile, 17, 16));
		gridPositions.Enqueue (new PrefabTile (powerTile, 7, 22));
		gridPositions.Enqueue (new PrefabTile (rockTile, 7, 23));
		gridPositions.Enqueue (new PrefabTile (rockTile, 8, 24));
		gridPositions.Enqueue (new PrefabTile (rockTile, 8, 21));
		gridPositions.Enqueue (new PrefabTile (rockTile, 6, 21));
		gridPositions.Enqueue (new PrefabTile (rockTile, 8, 23));
		gridPositions.Enqueue (new PrefabTile (rockTile, 6, 23));
		gridPositions.Enqueue (new PrefabTile (powerTile, 12, 29));
		gridPositions.Enqueue (new PrefabTile (rockTile, 13, 28));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 28));
		gridPositions.Enqueue (new PrefabTile (rockTile, 13, 30));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 30));
		gridPositions.Enqueue (new PrefabTile (rockTile, 9, 23));
		gridPositions.Enqueue (new PrefabTile (rockTile, 9, 24));
		gridPositions.Enqueue (new PrefabTile (rockTile, 10, 24));
		gridPositions.Enqueue (new PrefabTile (rockTile, 10, 29));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 29));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 25));
		gridPositions.Enqueue (new PrefabTile (rockTile, 8, 22));
		gridPositions.Enqueue (new PrefabTile (rockTile, 12, 28));
		gridPositions.Enqueue (new PrefabTile (rockTile, 12, 27));
		gridPositions.Enqueue (new PrefabTile (rockTile, 10, 37));
		gridPositions.Enqueue (new PrefabTile (rockTile, 10, 36));
		gridPositions.Enqueue (new PrefabTile (rockTile, 9, 37));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 37));
		gridPositions.Enqueue (new PrefabTile (rockTile, 11, 39));
		gridPositions.Enqueue (new PrefabTile (resourceTile, 11, 38));
		gridPositions.Enqueue (new PrefabTile (powerTile, 17, 35));
		gridPositions.Enqueue (new PrefabTile (rockTile, 18, 34));
		gridPositions.Enqueue (new PrefabTile (rockTile, 16, 34));
		gridPositions.Enqueue (new PrefabTile (rockTile, 18, 36));
		gridPositions.Enqueue (new PrefabTile (rockTile, 16, 36));
		gridPositions.Enqueue (new PrefabTile (powerTile, 5, 39));
		gridPositions.Enqueue (new PrefabTile (rockTile, 6, 38));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 38));
		gridPositions.Enqueue (new PrefabTile (rockTile, 6, 40));
		gridPositions.Enqueue (new PrefabTile (rockTile, 4, 40));

	}
}
