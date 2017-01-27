using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowObject : MonoBehaviour {

	public float sensitivity;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _targetPosition;

	void Start ()
	{
		sensitivity = 0.4f;
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
			transform.Rotate (new Vector3 (-(_mouseOffset.x + _mouseOffset.y + _mouseOffset.z) * sensitivity, 0.0f, 0.0f));

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
			_targetPosition = Camera.main.WorldToScreenPoint (transform.position);
			Debug.Log (_mouseOffset);

			// rotate
			Check_Rotation();

			// store mouse
			_mouseReference = Input.mousePosition;
		}

	}

	void Check_Rotation()
	{
		// Going east, north west quarter
		if (_mouseOffset.x > 0.0f && _mouseOffset.y > 0.0f && Input.mousePosition.x < _targetPosition.x) {
			transform.Rotate (new Vector3 (0.0f, (Mathf.Abs (_mouseOffset.x) + Mathf.Abs (_mouseOffset.y)) * sensitivity, 0.0f));
		}

		// Going west, south west quarter
		else if (_mouseOffset.x < 0.0f && _mouseOffset.y > 0.0f && Input.mousePosition.x < _targetPosition.x) {
			transform.Rotate (new Vector3 (0.0f, (Mathf.Abs (_mouseOffset.x) + Mathf.Abs (_mouseOffset.y)) * sensitivity, 0.0f));
		}

		// Going west, south east quarter
		else if (_mouseOffset.x < 0.0f && _mouseOffset.y < 0.0f && Input.mousePosition.x > _targetPosition.x) {
			transform.Rotate (new Vector3 (0.0f, (Mathf.Abs (_mouseOffset.x) + Mathf.Abs (_mouseOffset.y)) * sensitivity, 0.0f));
		}

		// Going east, north east quarter
		else if (_mouseOffset.x > 0.0f && _mouseOffset.y < 0.0f && Input.mousePosition.x > _targetPosition.x) {
			transform.Rotate (new Vector3 (0.0f, (Mathf.Abs (_mouseOffset.x) + Mathf.Abs (_mouseOffset.y)) * sensitivity, 0.0f));
		}

		// Going west, north west quarter
		else if (_mouseOffset.x < 0.0f && _mouseOffset.y < 0.0f && Input.mousePosition.x < _targetPosition.x) {
			transform.Rotate (new Vector3 (0.0f, -(Mathf.Abs (_mouseOffset.x) + Mathf.Abs (_mouseOffset.y)) * sensitivity, 0.0f));
		}

		// Going east, south west quarter
		else if (_mouseOffset.x > 0.0f && _mouseOffset.y < 0.0f && Input.mousePosition.x < _targetPosition.x) {
			transform.Rotate (new Vector3 (0.0f, -(Mathf.Abs (_mouseOffset.x) + Mathf.Abs (_mouseOffset.y)) * sensitivity, 0.0f));
		}

		// Going east, south east quarter
		else if (_mouseOffset.x > 0.0f && _mouseOffset.y > 0.0f && Input.mousePosition.x > _targetPosition.x) {
			transform.Rotate (new Vector3 (0.0f, -(Mathf.Abs (_mouseOffset.x) + Mathf.Abs (_mouseOffset.y)) * sensitivity, 0.0f));
		}

		// Going west, north east quarter
		else if (_mouseOffset.x < 0.0f && _mouseOffset.y > 0.0f && Input.mousePosition.x > _targetPosition.x) {
			transform.Rotate (new Vector3 (0.0f, -(Mathf.Abs (_mouseOffset.x) + Mathf.Abs (_mouseOffset.y)) * sensitivity, 0.0f));
		}
	}
}
