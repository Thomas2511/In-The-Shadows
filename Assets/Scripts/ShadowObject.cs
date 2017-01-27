using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowObject : MonoBehaviour {

	private float _sensitivity;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;

	void Start ()
	{
		_sensitivity = 0.4f;
	}

	void Update()
	{
		
	}

	void OnMouseDown()
	{
		// store mouse
		_mouseReference = Input.mousePosition;
	}

	void OnMouseDrag()
	{
		// horizontal rotation
		if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl)) {
			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);

			// rotate
			transform.Rotate (new Vector3 (-(_mouseOffset.x + _mouseOffset.y + _mouseOffset.z) * _sensitivity, 0.0f, 0.0f));

			// store mouse
			_mouseReference = Input.mousePosition;
		}

		else if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
		{
			
		}

		// vertical rotation
		else
		{
			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);

			// rotate
			if (_mouseOffset.x > transform.position.x && _mouseOffset.y > transform.position.y)
				transform.Rotate(new Vector3(0.0f, (_mouseOffset.x + _mouseOffset.y) * _sensitivity,0.0f));

			else if (_mouseOffset.x < transform.position.x && _mouseOffset.y > transform.position.y)
				transform.Rotate(new Vector3(0.0f, (-_mouseOffset.x + _mouseOffset.y) * _sensitivity,0.0f));

			else if (_mouseOffset.x > transform.position.x && _mouseOffset.y < transform.position.y)
				transform.Rotate(new Vector3(0.0f, (_mouseOffset.x - _mouseOffset.y) * _sensitivity,0.0f));

			else if (_mouseOffset.x < transform.position.x && _mouseOffset.y < transform.position.y)
				transform.Rotate(new Vector3(0.0f, -(_mouseOffset.x + _mouseOffset.y) * _sensitivity,0.0f));

			// store mouse
			_mouseReference = Input.mousePosition;
		}

	}
}
