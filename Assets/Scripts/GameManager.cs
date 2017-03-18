using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private enum stateType
    {
        DEFAULT,
        PAUSED,
        PLAYING,
        ENDED
    };

	private stateType _state { get; set; }
	public bool isPaused { get { return _state != stateType.PLAYING; } }

	void OnEnable()
	{
		Level.OnLevelEnd += SetStateToEnd;
		SceneManager.activeSceneChanged += SetStateToPlay;
	}

	void OnDisable()
	{
		Level.OnLevelEnd -= SetStateToEnd;
		SceneManager.activeSceneChanged -= SetStateToPlay;
	}

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			if (_state == stateType.PLAYING)
				_state = stateType.PAUSED;
			else if (_state == stateType.PAUSED)
				_state = stateType.PLAYING;
		}
		ReactOnState ();
    }

	void ReactOnState() 
	{
		switch(_state)
		{
			case stateType.PLAYING:
				break;
			case stateType.PAUSED:
				DisplayCursor ();
				break;
			case stateType.ENDED:
				DisplayCursor ();
				break;
			default:
				Debug.Log("ERROR: Unknown game state: " + _state);
				break;
		}
	}

	void DisplayCursor()
	{
		Cursor.visible = true;
	}

	void LevelValidated()
	{
		if (PlayerPrefs.HasKey("Current Level"))
		{
			if (PlayerPrefs.GetInt("Current Level") < 3)
				PlayerPrefs.SetInt("Current Level", PlayerPrefs.GetInt("Current Level") + 1);
		}
		else
			PlayerPrefs.SetInt("Current Level", 1);
	}

	void SetStateToPlay(Scene previousScene, Scene currentScene)
	{
		_state = stateType.PLAYING;
	}

    void SetStateToEnd()
    {
		LevelValidated();
        _state = stateType.ENDED;   
    }

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
}
