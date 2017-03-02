using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public List<GameObject> levelGroups;
    public List<GameObject> levelIcons;
    public List<Sprite> levelSprites;
    public int totalLevels;

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("Current Level");
    }

    public void UnlockAllLevels()
    {
        foreach(GameObject level in levelGroups)
        {
            level.SetActive(true);
        }
        for (int i = 0; i < totalLevels; i++)
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
        ResetLevelProgress();
        int currentLvl = (PlayerPrefs.HasKey("Current Level") ? PlayerPrefs.GetInt("Current Level") : 0);

        for (int i = 0; i <= currentLvl; i++)
        {
            levelGroups[i].SetActive(true);
            levelIcons[i].GetComponent<CanvasGroup>().alpha = 1;
            levelIcons[i].GetComponent<CanvasGroup>().interactable = true;
            levelIcons[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        levelIcons[currentLvl].GetComponent<Image>().sprite = levelSprites[4];
    }

    void Start()
    {
        UnlockToCurrent();
    }
}
