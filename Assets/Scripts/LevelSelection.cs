using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {

    public List<GameObject> levelGroups;
    public List<GameObject> levelIcons;
    public List<Sprite> levelSprites;
	public int maxLevel;

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("Current Level");
        UnlockToCurrent();
    }

    public void UnlockAllLevels()
    {
        foreach(GameObject level in levelGroups)
        {
            level.SetActive(true);
        }
		for (int i = 0; i < maxLevel; i++)
        {
            levelIcons[i].GetComponent<Image>().sprite = levelSprites[i];
        }
        foreach(GameObject icon in levelIcons)
        {
            icon.GetComponent<CanvasGroup>().alpha = 1;
            icon.GetComponent<CanvasGroup>().interactable = true;
            icon.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    void ResetLevelProgress()
    {
        foreach (GameObject level in levelGroups)
        {
            level.SetActive(false);
        }
        foreach (GameObject icon in levelIcons)
        {
            icon.GetComponent<CanvasGroup>().alpha = 0;
            icon.GetComponent<CanvasGroup>().interactable = false;
            icon.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void UnlockToCurrent()
    {
        int currentLvl = (PlayerPrefs.HasKey("Current Level") ? PlayerPrefs.GetInt("Current Level") : 0);

		ResetLevelProgress();

		for (int i = 0; i <= currentLvl && i <= maxLevel; i++)
        {
            levelGroups[i].SetActive(true);
            levelIcons[i].GetComponent<CanvasGroup>().alpha = 1;
            levelIcons[i].GetComponent<CanvasGroup>().interactable = true;
            levelIcons[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
		if (currentLvl <= maxLevel) {
			levelIcons [currentLvl].GetComponent<Image> ().sprite = levelSprites [levelSprites.Count - 1];
		}
    }

    void Start()
    {
        UnlockToCurrent();
    }
}

