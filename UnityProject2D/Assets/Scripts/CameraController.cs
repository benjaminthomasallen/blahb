using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public int scrollArea = 100;
	public int scrollSpeed = 20;
	public int dragSpeed = 3;
	Transform myTransform;

	const float orthographicSizeMin = 5f;
	const float orthographicSizeMax = 15f;
	
	void Start()
	{
		myTransform = transform;
		var zoom = 7;
		Camera.main.transform.position = new Vector3(10f, 6f, -10f);
		Camera.main.orthographicSize = zoom;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float mPosX = Input.mousePosition.x;
		float mPosY = Input.mousePosition.y;
		
		// Do camera movement by mouse position
		// mouse left
		if ((mPosX < scrollArea) && (transform.position.x > 8)){
			myTransform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime, Space.World);
		}
		// mouse right
		if ((mPosX >= Screen.width-scrollArea) && (transform.position.x < 11.5)) {
			myTransform.Translate(Vector3.right * scrollSpeed * Time.deltaTime, Space.World);
		}
		//mouse down
		if ((mPosY < scrollArea) && (transform.position.y > 6)) {
			myTransform.Translate(Vector3.up * -scrollSpeed * Time.deltaTime, Space.World);
		}
		// mouse up
		if ((mPosY >= Screen.height-scrollArea) && (transform.position.y < 43.5)) {
			myTransform.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.World);
		}

		//Scrolling Zoom
		if (Input.GetAxis("Mouse ScrollWheel") < -0) // forward
		{
			Camera.main.orthographicSize *= 1.1f;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > -0) // back
		{
			Camera.main.orthographicSize *= 0.9f;
		}
		
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax );
		
		
	}
}
