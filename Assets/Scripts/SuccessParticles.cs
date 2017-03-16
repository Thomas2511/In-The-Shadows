using System.Collections;using System.Collections.Generic;using UnityEngine;public class SuccessParticles : MonoBehaviour {    void OnEnable()
    {
        Level.OnLevelEnd += SuccessEffects;
    }

    void OnDisable()
    {
        Level.OnLevelEnd -= SuccessEffects;
    }    public void SuccessEffects()    {        this.gameObject.GetComponent<ParticleSystem>().Play();    }}