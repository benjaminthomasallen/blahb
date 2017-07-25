using UnityEngine;
using System.Collections;

public class GameplayManager : MonoBehaviour {

	public DefaultUnit[,] PlayerUnits = new DefaultUnit[20, 50];
	public GameObject unit1Prefab;
	public GameObject unit2Prefab;

	private Transform UnitHolder;
	private Vector2 mouseOver;
	private float minorOffset = 0.3f;
	private DefaultUnit selectedUnit;
	private Vector2 startDrag;
	private Vector2 endDrag;

	// Use this for initialization
	void Start () {
		//SpawnUnits ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMouseOver ();

		int x = (int)mouseOver.x;
		int y = (int)mouseOver.y;

		if (selectedUnit != null)
			UpdateUnitMove (selectedUnit);

		if (Input.GetMouseButtonDown (0))
			SelectUnit (x, y);

		if (Input.GetMouseButtonUp (0))
			TryMove ((int)startDrag.x,(int)startDrag.y, x, y);
	}

	private void UpdateMouseOver() {
		RaycastHit hit;

		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Tile"))) {
			mouseOver.x = (int)(hit.point.x + minorOffset);
			mouseOver.y = (int)(hit.point.y + minorOffset);
		}
		else {
			mouseOver.x = -1;
			mouseOver.y = -1;
		}
	}

	private void UpdateUnitMove(DefaultUnit defUnit) {
		RaycastHit hit;
		
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 25.0f, LayerMask.GetMask ("Tile"))) {
			defUnit.transform.position = hit.point;
		}
	}

	private void SelectUnit(int x, int y) {
		if (x < 0 || x >= 20 || y < 0 || y >= 50) {
			return;
		}

		DefaultUnit defUnit = PlayerUnits [x, y];
		if (defUnit != null) {
			selectedUnit = defUnit;
			startDrag = mouseOver;
			Debug.Log (selectedUnit.name);
		}
	}

	private void TryMove(int x1, int y1, int x2, int y2) {
		startDrag = new Vector2(x1, y1);
		endDrag = new Vector2(x2, y2);
		selectedUnit = PlayerUnits [x1, y1];

		//MoveUnit (selectedUnit, x2, y2);

		// Out of bounds
		if (x2 < 0 || x2 >= 20 || y2 < 0 || y2 >= 50) {
			if (selectedUnit != null)
				MoveUnit(selectedUnit, x1, y1);

			startDrag = Vector2.zero;
			selectedUnit = null;
			return;
		}
		// Mouse has not moved
		if (selectedUnit != null) {
			if (endDrag == startDrag) {
				MoveUnit (selectedUnit, x1, y1);
				startDrag = Vector2.zero;
				selectedUnit = null;
				return;
			}
		}

		// Check for valid move
		//if (selectedUnit.ValidMovement (PlayerUnits, x1, y1, x2, y2)) {
			// Was something jumped
			/*
				if (Mathf.Abs(x2-x1) == 2) {
					DefaultUnit defUnit = PlayerUnits[(x1+x2)/2, (y1+y2)/2];
					if (defUnit != null) {
						PlayerUnits[(x1+x2)/2, (y1+y2)/2] = null;
						Destroy(defUnit);
					}
				}
			 */
			//PlayerUnits[x2, y2] = selectedUnit;
			//PlayerUnits[x1, y1] = null;
			//MoveUnit (selectedUnit, x2, y2);

			//EndTurn();
		//}
	}

	private void EndTurn() {

	}

	public void SpawnUnits () {
		UnitHolder = new GameObject ("Units").transform;
		for (int x = 0; x < 3; x++) {
			for (int y = 0; y < 4; y += 2) {
				InstantiateUnit(x, y);
			}
		}
	}

	private void InstantiateUnit (int x, int y) {
		GameObject tempGO = Instantiate (unit1Prefab, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
		tempGO.transform.SetParent (UnitHolder);
		DefaultUnit defUnit = tempGO.GetComponent<DefaultUnit> ();
		PlayerUnits [x, y] = defUnit;
		MoveUnit (defUnit, x, y);
	}

	private void MoveUnit(DefaultUnit defUnit, int x, int y) {
		defUnit.transform.position = (Vector3.right * x) + (Vector3.up * y);
	}
}
