using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public List<ShadowObject> shadowObjects;
    public delegate void LevelEnded();
    public static event LevelEnded OnLevelEnd;

	private bool success;

	void Start () {
		success = false;
	}

	void Update () {
        if (Input.GetKeyUp(KeyCode.Tab))
            SelectNextObject();

		if (IsSuccess() && IsSuccessCollider() && success != true)
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
        foreach (ShadowObject shadow in shadowObjects)
        {
            Quaternion successRotation = Quaternion.Euler(new Vector3(shadow.successX, shadow.successY, shadow.successZ));

            //Debug.Log("Quaternion angle : " + Quaternion.Angle(shadow.transform.rotation, successRotation));

			if (Quaternion.Angle(shadow.transform.rotation, successRotation) < shadow.detailLevel && !Input.GetMouseButton(0))
                return true;
        }

        return false;
    }

    bool IsSuccessCollider()
    {
        if (shadowObjects.Count <= 1) return true;
        else
        {
            foreach (ShadowObject shadow in shadowObjects)
            {
                foreach (ShadowObject other in shadowObjects)
                {
                    if (other != shadow && other.gameObject.GetComponentInChildren<BoxCollider>().bounds.Intersects(shadow.GetComponentInChildren<BoxCollider>().bounds))
                        return true;
                }
            }
        }
        return false;
    }
}
