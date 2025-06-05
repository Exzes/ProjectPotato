using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ProjectPotato;

public class WarningTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _warningPanel;
    void Awake()
    {
        _warningPanel.SetActive(false);
    }
    public void OnPlayClicked()
    {
        int _completed = PlayerPrefs.GetInt("TutorialCompleted", 0);

        if (_completed == 0)
        {
            _warningPanel.SetActive(true);
        }
        else
        {
            LoadScenes.ChangeSceneWhitLoader(5);
            var animController = FindObjectOfType<CineMachineController>();
            animController?.StartSceneAnimation();
            //SceneManager.LoadScene("GameLevelOne");
        }
    }
    public void OnTutorialChoice(bool playerChoice)
    {
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        if (playerChoice)
        {
            LoadScenes.ChangeSceneWhitLoader(3);
            //SceneManager.LoadScene("TutorialScreen");
        }
        else
        {
            LoadScenes.ChangeSceneWhitLoader(5);
            //SceneManager.LoadScene("GameLevelOne");
        }
        
    }
}
