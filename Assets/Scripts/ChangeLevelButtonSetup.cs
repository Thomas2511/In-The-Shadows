using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevelButtonSetup : MonoBehaviour {

	public int levelIndex;

	void Awake () {
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => GameManager.instance.LoadLevel (levelIndex));
	}

}
