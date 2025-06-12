using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButtons : MonoBehaviour
{
    public void BackScene()
    {
        SceneManager.LoadScene(PreviousScene.PreviousSceneName);
        PreviousScene.PreviousSceneName = SceneManager.GetActiveScene().name;
    }
}
