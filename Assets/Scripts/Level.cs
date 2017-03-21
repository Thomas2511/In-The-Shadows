using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public List<ShadowObject> shadowObjects;
	public List<BoxCollider> successRotations;

    public delegate void LevelEnded();
    public static event LevelEnded OnLevelEnd;

	private bool success;

	void Start () {
		success = false;
	}

	void Update () {
        if (Input.GetKeyUp(KeyCode.Tab))
            SelectNextObject();

		if (!Input.GetMouseButton(0) && (IsSuccess() || IsSuccessCollider()) && success != true)
        {
            success = true;
            if (OnLevelEnd != null)
                OnLevelEnd();
        }
	}

    void SelectNextObject()
    {
        for (int i = 0; i < shadowObjects.Count; i++)
        {
            if (shadowObjects[i].isSelected)
            {
                shadowObjects[i].isSelected = false;
                if (i == shadowObjects.Count - 1)
                    shadowObjects[0].isSelected = true;
                else
                    shadowObjects[i + 1].isSelected = true;
                return;
            }
        }
    }

    bool IsSuccess()
    {
		if (shadowObjects.Count <= 1) {
			bool xIsOk = false;
			bool yIsOk = false;
			bool zIsOk = false;

			foreach (float i in shadowObjects[0].successX) {
				if ((shadowObjects[0].transform.localRotation.eulerAngles.x % 180.0f) >= i - shadowObjects[0].detailLevel &&
					(shadowObjects[0].transform.localRotation.eulerAngles.x % 180.0f) <= i + shadowObjects[0].detailLevel)
					xIsOk = true;
			}
			foreach (float j in shadowObjects[0].successY) {
				if ((shadowObjects[0].transform.localRotation.eulerAngles.y % 180.0f) >= j - shadowObjects[0].detailLevel &&
					(shadowObjects[0].transform.localRotation.eulerAngles.y % 180.0f) <= j + shadowObjects[0].detailLevel)
					yIsOk = true;
			}
			foreach (float k in shadowObjects[0].successZ) {
				if ((shadowObjects[0].transform.localRotation.eulerAngles.z % 180.0f) >= k - shadowObjects[0].detailLevel &&
					(shadowObjects[0].transform.localRotation.eulerAngles.z % 180.0f) <= k + shadowObjects[0].detailLevel)
					zIsOk = true;
			}
			if ((xIsOk || shadowObjects[0].anyX) && (yIsOk || shadowObjects[0].anyY) && (zIsOk || shadowObjects[0].anyZ))
				return true;
		}
		return false;
    }
	

    bool IsSuccessCollider()
    {
		if (shadowObjects.Count > 1) {
            foreach (ShadowObject shadow in shadowObjects)
            {
                foreach (ShadowObject other in shadowObjects) {
                    if (other != shadow && other.gameObject.GetComponentInChildren<BoxCollider>().bounds.Intersects(shadow.GetComponentInChildren<BoxCollider>().bounds))
                        return true;
                }
            }
        }
        return false;
    }
}
