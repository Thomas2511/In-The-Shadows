﻿using System.Collections;using System.Collections.Generic;using UnityEngine;public class GameManager : MonoBehaviour {    public static GameManager   instance;    public delegate void SuccessEventHandler();    public static event SuccessEventHandler OnSuccess;    public bool success;    public List<ShadowObject> shadowObjects;    public GameObject spotlight;    void Update()    {        if (IsSuccess() && !success) {            //success = true;            if (OnSuccess != null)                OnSuccess();        }    }    bool IsSuccess()    {        float angle;        //Vector3 cross;        foreach(ShadowObject shadow in shadowObjects)        {            angle = Vector3.Angle(shadow.transform.forward, spotlight.transform.forward);            //cross = Vector3.Cross(shadow.transform.forward, spotlight.transform.forward);            Debug.Log(angle);            //Debug.Log(cross);            // angle in [0,180]            //float sign = Mathf.Sign(Vector3.Dot(spotlight.transform.forward, Vector3.Cross(shadow.transform.forward, spotlight.transform.forward)));            // angle in [-179,180]            //float signed_angle = angle * sign;            //Debug.Log(signed_angle);            if (angle > 89.0f && angle < 91.0f && OnSuccess != null) {                return true;            }        }        return false;    }}