using UnityEngine;
using System.Collections;

public class DefaultUnit : MonoBehaviour {

	public bool isTeam1;

	public bool ValidMovement(DefaultUnit[,] tracker, int x1, int y1, int x2, int y2) {
		// If movement is on top of another piece
		if (tracker [x2, y2] != null)
			return false;

		int deltaMoveX = Mathf.Abs (x1 - x2);
		int deltaMoveY = Mathf.Abs (y1 - y2);
		if (isTeam1) {
			if (deltaMoveX == 1) {
				if (deltaMoveY == 1)
					return true;
			}
			/*
			 * else if (deltaMoveX == 2) {
			 * 		if (deltaMoveY == 2) {
			 * 			DefaultUnit defUnit = tracker[(x1 + x2) / 2, (y1 + y2) / 2];
			 * 			if (defUnit != null && defUnit != isTeam1)
			 * 				return true;
			 * 		}
			 * }
			 */
		}

		if (!isTeam1) {
			if (deltaMoveX == 1) {
				if (deltaMoveY == 1)
					return true;
			}
			/*
			 * else if (deltaMoveX == 2) {
			 * 		if (deltaMoveY == 2) {
			 * 			DefaultUnit defUnit = tracker[(x1 + x2) / 2, (y1 + y2) / 2];
			 * 			if (defUnit != null && defUnit != isTeam1)
			 * 				return true;
			 * 		}
			 * }
			 */
		}

		return false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
