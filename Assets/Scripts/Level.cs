using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public bool success = false;
    public List<ShadowObject> shadowObjects;
    public delegate void LevelEnded();
    public static event LevelEnded OnLevelEnd;
    public Spotlight spotlight;
    public SuccessParticles particles;

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

            Debug.Log("Quaternion angle : " + Quaternion.Angle(shadow.transform.rotation, successRotation));

            if (Quaternion.Angle(shadow.transform.rotation, successRotation) < 3.0f && !Input.GetMouseButton(0))
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
