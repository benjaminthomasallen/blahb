using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public int scrollArea = 100;
    public int scrollSpeed = 20;
    public int dragSpeed = 3;

    public float xLimitLeft = 8f;
    public float xLimitRight = 11.5f;
    public float yLimitUp = 43.5f;
    public float yLimitDown = 6f;

    Transform myTransform;

    const float orthographicSizeMin = 2f;
    const float orthographicSizeMax = 15f;

    void Start()
    {
        myTransform = transform;
        var zoom = 7;
        Camera.main.transform.position = new Vector3(10f, 6f, -10f);
        Camera.main.orthographicSize = zoom;
    }

    // Update is called once per frame
    void Update()
    {
        float mPosX = Input.mousePosition.x;
        float mPosY = Input.mousePosition.y;

        // camera up
        if ((Input.GetKey(KeyCode.UpArrow)) && (transform.position.y < yLimitUp))
        {
            myTransform.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.World); ;
        }
        // camera down
        if ((Input.GetKey(KeyCode.DownArrow)) && (transform.position.y > yLimitDown))
        {
            myTransform.Translate(Vector3.up * -scrollSpeed * Time.deltaTime, Space.World);
        }
        // camera left
        if ((Input.GetKey(KeyCode.LeftArrow)) && (transform.position.x > xLimitLeft))
        {
            myTransform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime, Space.World);
        }
        // camera right
        if ((Input.GetKey(KeyCode.RightArrow)) && (transform.position.x < xLimitRight))
        {
            myTransform.Translate(Vector3.right * scrollSpeed * Time.deltaTime, Space.World);
        }

        // zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < -0)
        {
            Camera.main.orthographicSize *= 1.1f;
        }
        // zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > -0)
        {
            Camera.main.orthographicSize *= 0.9f;
        }

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);


    }
}
