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

    public Material currentMaterial;

    public bool isSelected;
    public float successX;
    public float successY;
    public float successZ;
	public float detailLevel;

    void Start()
    {
        currentMaterial.EnableKeyword("_Emission");
    }

    public void Update()
	{
		if (GameManager.instance.isPaused)
			return;

        if (isSelected)
            gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0.33f, 0.33f, 0.33f));
        else
            gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f));

        if (Input.GetMouseButtonUp(0))
            Cursor.visible = true;

        if (Input.GetMouseButton(0) && isSelected) {
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
        if (!Input.GetKey(KeyCode.LeftControl) &&
            !Input.GetKey(KeyCode.RightControl) &&
            !Input.GetKey(KeyCode.LeftShift) &&
            !Input.GetKey(KeyCode.RightShift) &&
            horizontalAvailable &&
            !freeMovementAvailable)
        {
            transform.Rotate(new Vector3(0.0f, -mouseOffset.x * sensitivity, 0.0f), Space.World);
        }
    }

    void VerticalMovement()
    {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) &&
            !Input.GetKey(KeyCode.LeftShift) &&
            !Input.GetKey(KeyCode.RightShift) &&
            verticalAvailable &&
            !freeMovementAvailable)
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
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) &&
            !Input.GetKey(KeyCode.LeftControl) &&
            !Input.GetKey(KeyCode.RightControl) &&
            moveElementsAvailable)
        {
            transform.Translate(mouseOffset * sensitivity * Time.deltaTime, Space.World);
        }
    }
}
