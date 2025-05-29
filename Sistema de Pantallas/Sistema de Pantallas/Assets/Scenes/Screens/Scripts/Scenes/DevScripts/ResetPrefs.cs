using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPrefs : MonoBehaviour
{
    void Awake()
    {
        PreviousScene.PreviousSceneName = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(gameObject);
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(600, 10, 150, 30), "WarningReset"))
        {
            ResetPlayerPrefs();
        }
        else if (GUI.Button(new Rect(600, 40, 150, 30), "WarningOff"))
        {
            PlayerPrefs.SetInt("TutorialCompleted", 1);
        }
        else if (GUI.Button(new Rect(600, 80, 150, 30), "Back"))
        {
            SceneManager.LoadScene(PreviousScene.PreviousSceneName);
            PreviousScene.PreviousSceneName = SceneManager.GetActiveScene().name;
        }
    }
    private void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("TutorialCompleted");
    }
}
