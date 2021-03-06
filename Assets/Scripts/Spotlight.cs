﻿using System.Collections;using System.Collections.Generic;using UnityEngine;public class Spotlight: MonoBehaviour {    void OnEnable()
    {
        Level.OnLevelEnd += SuccessEffects;
    }

    void OnDisable()
    {
        Level.OnLevelEnd -= SuccessEffects;
    }    public void SuccessEffects()    {        this.GetComponent<Light>().color = Color.yellow;        StartCoroutine(LerpToColor());    }    IEnumerator LerpToColor()    {        while (this.GetComponent<Light>().color != Color.white)        {            this.GetComponent<Light>().color = Color.Lerp(this.GetComponent<Light>().color, Color.white, 0.1f);            yield return new WaitForSeconds(0.1f);        }    }}