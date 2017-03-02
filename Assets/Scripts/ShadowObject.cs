using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowObject : MonoBehaviour {

    public bool horizontalAvailable;
    public bool verticalAvailable;
    public bool moveElementsAvailable;
    public bool freeMovementAvailable;
    public float sensitivity;
	private Vector3 mouseOffset;
    private bool controlsEnabled;

    public void Start()
    {
        controlsEnabled = true;
    }

	public void Update()
	{
        if (!Input.GetMouseButton(0) || !controlsEnabled)
        {
            Cursor.visible = true;
            return;
        }

        if (Input.GetMouseButtonDown(0)) {
            Cursor.visible = false;
        }

        mouseOffset = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);

        HorizontalMovement();
        VerticalMovement();
        FreeMovement();
        MoveElements();
            
	}

    void HorizontalMovement()
    {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && horizontalAvailable)
        {
            transform.Rotate(new Vector3(0.0f, -mouseOffset.x * sensitivity, 0.0f), Space.World);
        }
    }

    void VerticalMovement()
    {
        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && verticalAvailable)
        {
            transform.Rotate(new Vector3(-mouseOffset.y * sensitivity, 0.0f, 0.0f), Space.World);
        }
    }

    void FreeMovement()
    {
        if (freeMovementAvailable)
        {
            transform.Rotate(new Vector3(-mouseOffset.y * sensitivity, -mouseOffset.x * sensitivity, 0.0f), Space.World);
        }
    }

    void MoveElements()
    {
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && moveElementsAvailable)
        {
            transform.Translate(mouseOffset * sensitivity * Time.deltaTime, Space.World);
        }
    }

    public void EnableControls()
    {
        controlsEnabled = true;
    }

    public void DisableControls()
    {
        controlsEnabled = false;
    }
}
