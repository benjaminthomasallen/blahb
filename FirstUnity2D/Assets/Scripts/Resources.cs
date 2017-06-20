using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {
	
	public Sprite thirtythreeSprite;
	public Sprite sixtysixSprite;
	public Sprite depletedSourceSprite;
	public int resources = 3;
	public bool isPowerSpot;
	public bool isDepleted = false;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public void AcquireResource (int acquire) {
		resources -= acquire;
		if (resources == 2)
			spriteRenderer.sprite = thirtythreeSprite;
		else if (resources == 1)
			spriteRenderer.sprite = sixtysixSprite;
		else if (resources == 0)
			spriteRenderer.sprite = depletedSourceSprite;
		else
			isDepleted = true;
	}
}
