using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowObject : MonoBehaviour {

	public float sensitivity;
	private Vector3 _mouseOffset;
    private bool _gameover;

    void OnEnable()    {        GameManager.OnSuccess += GameOver;    }    void OnDisable()    {        GameManager.OnSuccess -= GameOver;    }

    void Start ()
	{
        _gameover = false;
    }

	void Update()
	{
        if (_gameover) {
            return;
        }

        if (Input.GetMouseButtonDown(0)) {
            Cursor.visible = false;
        }

        if (!Input.GetMouseButton(0)) {
            Cursor.visible = true;
            return;
        }

        _mouseOffset = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) {
            transform.Rotate(new Vector3(0.0f, -_mouseOffset.x * sensitivity, 0.0f), Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) {
            transform.Rotate(new Vector3(-_mouseOffset.y * sensitivity, 0.0f, 0.0f), Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            transform.Translate(_mouseOffset * sensitivity * Time.deltaTime, Space.World);
        }
        else {
            transform.Rotate(new Vector3(-_mouseOffset.y * sensitivity, -_mouseOffset.x * sensitivity, 0.0f), Space.World);
        }
            
	}

    void GameOver()
    {
        _gameover = true;
    }
}
