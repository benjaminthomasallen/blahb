using UnityEngine;
using UnityEngine.EventSystems;

/* EventTriggerer handles the main unit's events, the names of the functions cover what they do. */

public class EventTriggerer : MonoBehaviour
{
	private Rigidbody2D rBody2D;
	private BoardManager BScript;
	private GameObject[] requestedTile = new GameObject[10];
	private float previousX = 0f;
	private float previousY = 0f;

	void Start () {
		rBody2D = GetComponent<Rigidbody2D> ();
		BScript = GameObject.Find ("GameManager(Clone)").GetComponent<BoardManager>();
	}

	void Update () {

	}

	public void ExecuteMovement (float x, float y) {
		Vector2 start = rBody2D.position;
		Vector2 end = start + new Vector2 (x, y);

		//while ((int)rBody2D.position.x != (int)x && (int)rBody2D.position.y != (int)y) {
		Vector2 newPosition = Vector2.MoveTowards (rBody2D.position, end, 1f);
		rBody2D.MovePosition (newPosition);
		//}
		ShadeDown();
	}

	private void ShadeUp () {
		for (int i = 1; i < 3; i++) {
			requestedTile[i] = BScript.PassObject (((int)rBody2D.position.x + i), (int)rBody2D.position.y);
			requestedTile[i].GetComponent<TerrainMover>().FlipState();
			requestedTile[i].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
			requestedTile[i].GetComponent<BoxCollider2D>().enabled = true;
			//Debug.Log ("x: " + requestedTile[i].transform.position.x + ", y: " + requestedTile[i].transform.position.y);
		}
		for (int i = 1; i < 3; i++) {
			requestedTile[i] = BScript.PassObject ((int)rBody2D.position.x, ((int)rBody2D.position.y + i));
			requestedTile[i].GetComponent<TerrainMover>().FlipState();
			requestedTile[i].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
			requestedTile[i].GetComponent<BoxCollider2D>().enabled = true;
			//Debug.Log ("x: " + requestedTile[i].transform.position.x + ", y: " + requestedTile[i].transform.position.y);
		}
	}

	private void ShadeDown () {
		for (int i = 1; i < 3; i++) {
			requestedTile[i] = BScript.PassObject ((int)(previousX + i), (int)rBody2D.position.y);
			requestedTile[i].GetComponent<TerrainMover>().FlipState();
			requestedTile[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
			requestedTile[i].GetComponent<BoxCollider2D>().enabled = false;
			//Debug.Log ("x: " + requestedTile[i].transform.position.x + ", y: " + requestedTile[i].transform.position.y);
		}
		for (int i = 1; i < 3; i++) {
			requestedTile[i] = BScript.PassObject ((int)rBody2D.position.x, (int)(previousY + i));
			requestedTile[i].GetComponent<TerrainMover>().FlipState();
			requestedTile[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
			requestedTile[i].GetComponent<BoxCollider2D>().enabled = false;
			//Debug.Log ("x: " + requestedTile[i].transform.position.x + ", y: " + requestedTile[i].transform.position.y);
		}
		previousX = rBody2D.position.x;
		previousY = rBody2D.position.y;
	}

	private void OnMouseDown(){
		requestedTile [0] = BScript.PassObject (3, 6);
		previousX = rBody2D.position.x;
		previousY = rBody2D.position.y;
		ShadeUp ();
	}

	private void OnMouseEnter() {
		GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
		//Debug.Log (rBody2D.position.x);
		//Debug.Log (rBody2D.position.y);
	}

	private void OnMouseExit() {
		GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
	}
}