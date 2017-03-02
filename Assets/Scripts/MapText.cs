using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapText : MonoBehaviour {

    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            this.gameObject.GetComponent<Text>().text = hit.collider.gameObject.name;
        }
        else
        {
            this.gameObject.GetComponent<Text>().text = "";
        }
    }
}
