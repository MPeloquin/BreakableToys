using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;

    public float minY = 10f;
    public float maxY = 80f;

    private bool allowMovement = true;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            allowMovement = !allowMovement;
        }

        if (!allowMovement)
            return;

	    if (Input.GetAxis("Vertical") > 0 || Input.mousePosition.y >= Screen.height - panBorderThickness)
	    {
	        transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
	    }

        if (Input.GetAxis("Vertical") < 0 || Input.mousePosition.y <= panBorderThickness)
	    {
	        transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
	    }

        if (Input.GetAxis("Horizontal") < 0 || Input.mousePosition.x <= panBorderThickness)
	    {
	        transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
	    }

        if (Input.GetAxis("Horizontal") > 0 || Input.mousePosition.x >= Screen.width - panBorderThickness)
	    {
	        transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
	    }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 250 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
