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

    public float successX;
    public float successY;
    public float successZ;
	public float detailLevel;

    public void Update()
	{
		if (GameManager.instance.isPaused)
			return;

		if (Input.GetMouseButtonUp(0))
            Cursor.visible = true;

        if (Input.GetMouseButton(0)) {
            Cursor.visible = false;

			mouseOffset = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);

			HorizontalMovement();
			VerticalMovement();
			FreeMovement();
			MoveElements();
        }
	}

    void HorizontalMovement()
    {
        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl) && horizontalAvailable && !freeMovementAvailable)
        {
            transform.Rotate(new Vector3(0.0f, -mouseOffset.x * sensitivity, 0.0f), Space.World);
        }
    }

    void VerticalMovement()
    {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && verticalAvailable && !freeMovementAvailable)
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
}
