using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    
    public bool success;

    public List<ShadowObject> shadowObjects;

    public GameObject spotlight;
    public int level;

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
                EnablePlay();
                break;
            case stateType.PAUSED:
                DisablePlay();
                break;
            case stateType.ENDED:
                DisablePlay();
                break;
            default:
                Debug.Log("ERROR: Unknown game state: " + state);
                break;
        }

        if (IsSuccess() && !success) {
            spotlight.GetComponent<Spotlight>().SuccessEffects();
            state = stateType.ENDED;
        }
    }

    bool IsSuccess()
    {
        //float angle;
        //Vector3 cross;

        foreach(ShadowObject shadow in shadowObjects)
        {
            if (level == 1 && (shadow.transform.rotation.x >= 85 || shadow.transform.rotation.x <= 89) &&
                (shadow.transform.rotation.x >= 85 && shadow.transform.rotation.x <= 89) &&
                ((shadow.transform.rotation.y <= -393 && shadow.transform.rotation.y >= -395) || (shadow.transform.rotation.y <= -224 && shadow.transform.rotation.y >= -226)) &&
                (shadow.transform.rotation.z <= -168 && shadow.transform.rotation.z >= -170)) {
                success = true;
                if (PlayerPrefs.HasKey("Current Level"))
                {
                    if (PlayerPrefs.GetInt("Current Level") < 3)
                        PlayerPrefs.SetInt("Current Level", PlayerPrefs.GetInt("Current Level") + 1);
                }
                else
                    PlayerPrefs.SetInt("Current Level", 0);
                return true;
            }
            //angle = Vector3.Angle(shadow.transform.forward, spotlight.transform.forward);
            //cross = Vector3.Cross(shadow.transform.forward, spotlight.transform.forward);
            //Debug.Log(angle);
            //Debug.Log(cross);
            // angle in [0,180]
            //float sign = Mathf.Sign(Vector3.Dot(spotlight.transform.forward, Vector3.Cross(shadow.transform.forward, spotlight.transform.forward)));

            // angle in [-179,180]
            //float signed_angle = angle * sign;
            //Debug.Log(signed_angle);

            /*if (angle > 89.0f && angle < 91.0f && OnSuccess != null) {
                return true;
            }*/
        }
        return false;
    }

    public void EnablePlay()
    {
        foreach(ShadowObject shadow in shadowObjects)
        {
            shadow.EnableControls();
        }
    }

    public void DisablePlay()
    {
        foreach(ShadowObject shadow in shadowObjects)
        {
            shadow.DisableControls();
        }
    }

    public void LoadLevelsMap()
    {
        SceneManager.LoadScene(0);
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
