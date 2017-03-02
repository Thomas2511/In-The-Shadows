using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenu : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            InteractWithWindow();
        }
    }

    public void InteractWithWindow()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = (this.gameObject.GetComponent<CanvasGroup>().alpha == 0 ? 1 : 0);
        this.gameObject.GetComponent<CanvasGroup>().interactable ^= true;
        this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts ^= true;
    }
}
