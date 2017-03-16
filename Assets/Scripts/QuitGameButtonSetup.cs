using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameButtonSetup : MonoBehaviour {

	void Awake () {
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => GameManager.instance.QuitGame());
	}
}
