using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {

	void Update ()
    {
		if (GameManager.instance.isPaused)
			DisplayWindow ();
		else
			HideWindow ();
	}

    public void DisplayWindow()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        this.gameObject.GetComponent<CanvasGroup>().interactable = true;
        this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

	public void HideWindow()
	{
		this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
		this.gameObject.GetComponent<CanvasGroup>().interactable = false;
		this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
}
