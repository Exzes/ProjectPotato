using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public static PlayManager Instance;

    public bool canPlayerMove = true;
    public bool canEnemiesAtk = true;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetGamePlayState(bool state)
    {
        canPlayerMove = state;  
    }
    public void SetEventsState(bool state)
    {
        canEnemiesAtk = state;
    }
}
