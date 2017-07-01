using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float menuStartDelay = 2f;
	public float turnDelay = .1f;
	public static GameManager instance = null;
	public BoardManager boardScript;
	[HideInInspector] public bool playersTurn = true;

	private Text menuText;
	private GameObject menuImage;
	private bool doingSetup;
	private bool turnDelayActive;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	private void OnLevelWasLoaded (int index) {
		InitGame ();
	}

	void InitGame () {
		doingSetup = true;
		menuImage = GameObject.Find ("MenuImage");
		menuImage.SetActive (true);
		Invoke ("HideMenuImage", menuStartDelay);
		boardScript.SetupScene();
	}

	private void HideMenuImage () {
		menuImage.SetActive (false);
		doingSetup = false;
	}

	public void GameOver() {
		menuText.text = "End screen";
		menuImage.SetActive (true);
		enabled = false;
	}
	
	void Update () {
		if (playersTurn || doingSetup)
			return;
		StartCoroutine (turnDelayer ());
		//playersTurn = true;
	}

	IEnumerator turnDelayer () {
		turnDelayActive = true;
		yield return new WaitForSeconds(turnDelay);
		playersTurn = true;
		turnDelayActive = false;
	}
}
