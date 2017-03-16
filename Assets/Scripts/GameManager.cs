using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public enum stateType
    {
        DEFAULT,
        PAUSED,
        PLAYING,
        ENDED
    };

    public stateType state;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        state = stateType.PLAYING;
    }

    void Update()
    {
        switch(state)
        {
            case stateType.PLAYING:
                break;
            case stateType.PAUSED:
                break;
            case stateType.ENDED:
                break;
            default:
                Debug.Log("ERROR: Unknown game state: " + state);
                break;
        }
    }

    void StateToEnd()
    {
        this.state = stateType.ENDED;

        if (PlayerPrefs.HasKey("Current Level"))
        {
            if (PlayerPrefs.GetInt("Current Level") < 3)
                PlayerPrefs.SetInt("Current Level", PlayerPrefs.GetInt("Current Level") + 1);
        }
        else
            PlayerPrefs.SetInt("Current Level", 0);
    }

    void OnEnable()
    {
        Level.OnLevelEnd += StateToEnd;
    }
    
    void OnDisable()
    {
        Level.OnLevelEnd -= StateToEnd;
    }

    public void LoadLevel(int index)
    {
        state = stateType.PLAYING;
        SceneManager.LoadScene(index);
    }

    public void LoadLevel(string levelName)
    {
        state = stateType.PLAYING;
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
}
