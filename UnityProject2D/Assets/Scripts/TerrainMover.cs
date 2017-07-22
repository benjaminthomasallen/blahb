using UnityEngine;
using UnityEngine.EventSystems;

/* Should be allowing the unit to move based on the tile selected, mostly helps EventTriggerer. */

public class TerrainMover : MonoBehaviour {
	private bool MoverEnabled = false;
	private EventTriggerer BorrowedScript;
	
	void OnMouseDown(){
		if (MoverEnabled == true) {
			BorrowedScript = GameObject.Find ("Player1Token").GetComponent<EventTriggerer>();
			BorrowedScript.ExecuteMovement(this.transform.position.x, this.transform.position.y);
		}
	}

	public void FlipState () {
		MoverEnabled = !MoverEnabled;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
