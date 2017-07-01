using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {
	
	public Sprite ActivatedSprite;
	public int resources = 1;
	public int resourcePerAcquire = 50;
	public bool isPowerSpot;
	public bool isDepleted = false;
	
	private SpriteRenderer spriteRenderer;
	
	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	public void AcquireResource (int acquire) {
		resources -= acquire;
		if (isPowerSpot) {
			spriteRenderer.sprite = ActivatedSprite;
			isDepleted = true;
		} else if (resources >= 0) {
			;
		} else
			isDepleted = true;
	}
}
