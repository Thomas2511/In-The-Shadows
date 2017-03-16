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
		if (IsSuccess() && success != true)
        {
            success = true;
            if (OnLevelEnd != null)
                OnLevelEnd();
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
}
