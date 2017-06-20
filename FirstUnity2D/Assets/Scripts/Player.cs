using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MovingObject {

	public int acquireAmount = 1;
	public int resourcePerAcquire = 50;
	public float restartLevelDelay = 1f;
	public Text resourceText;

	private int resources = 0;

	// Use this for initialization
	protected override void Start () {
		resourceText.text = "Resources: " + resources;
		base.Start ();
	}

	private void OnDisable() {
		;
	}

	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.playersTurn)
			return;

		int horizontal = 0;
		int vertical = 0;

		horizontal = (int)Input.GetAxisRaw ("Horizontal");
		vertical = (int)Input.GetAxisRaw ("Vertical");

		if (horizontal != 0)
			vertical = 0;

		if (horizontal != 0 || vertical != 0)
			AttemptMove<Resources> (horizontal, vertical);
	}

	protected override void AttemptMove <T> (int xDir, int yDir) {
		base.AttemptMove <T> (xDir, yDir);

		RaycastHit2D hit;

		CheckIfGameOver ();

		GameManager.instance.playersTurn = false;
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "EnemyBase") {
			resources = 0;
			Invoke ("Restart", restartLevelDelay);
			enabled = false;
		}
	}

	protected override void OnCantMove <T> (T component) {
		Resources gatherResource = component as Resources;
		gatherResource.AcquireResource (acquireAmount);
		if (!gatherResource.isPowerSpot && !gatherResource.isDepleted) {
			resources += resourcePerAcquire;
			resourceText.text = "Resources: " + resources;
		}
	}

	private void Restart() {
		Application.LoadLevel (Application.loadedLevel);
	}

	private void CheckIfGameOver() {
		if (resources >= 1000) {
			GameManager.instance.GameOver ();
		}
	}
}
