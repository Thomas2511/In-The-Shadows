using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapText : MonoBehaviour {

    List<string> levelAdvices = new List<string>
    {
        "Afraid of mice",
        "Nice around five o'clock",
        "Answer to Everything"
    };

    public void SetText(int level)
    {
        this.gameObject.GetComponent<Text>().text = levelAdvices[level];
    }

    public void ResetText()
    {
        this.gameObject.GetComponent<Text>().text = "";
    }
}
