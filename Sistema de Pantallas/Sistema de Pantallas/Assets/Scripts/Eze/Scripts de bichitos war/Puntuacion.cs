using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Puntuacion : MonoBehaviour
{
    private int totalPoints;
    [SerializeField] TMP_Text points;
    void Start()
    {
       //totalPoints = ScoreManager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Puntuacion \n" + totalPoints.ToString();
    }
}
