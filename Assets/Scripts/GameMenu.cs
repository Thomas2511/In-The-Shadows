using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {

	void Update ()
    {
        if (GameManager.instance.state == GameManager.stateType.ENDED)
        {
            if (this.gameObject.GetComponent<CanvasGroup>().alpha == 0)
                InteractWithWindow();

            return;
        }

		if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameManager.instance.state = (GameManager.instance.state == GameManager.stateType.PLAYING ? GameManager.stateType.PAUSED : GameManager.stateType.PLAYING);
            InteractWithWindow();
        }
	}

    public void InteractWithWindow()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = (this.gameObject.GetComponent<CanvasGroup>().alpha == 0 ? 1 : 0 );
        this.gameObject.GetComponent<CanvasGroup>().interactable ^= true;
        this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts ^= true;
    }
}
