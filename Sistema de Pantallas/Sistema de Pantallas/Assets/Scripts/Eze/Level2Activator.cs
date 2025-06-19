using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Level2Activator : MonoBehaviour
{
    [SerializeField] private GameObject forest;
    [SerializeField] private GameObject construction;
    [SerializeField] private GameObject extractionZone;
    [SerializeField] private Material skyBoxMat;
    [SerializeField] private GameObject DayMode;

    private void Start()
    {
        extractionZone.SetActive(false);
        construction.SetActive(false);
        GameStateManager.Instance.OnWinConditionReady += EnableWinObject;
    }

    private void EnableWinObject()
    {
        extractionZone.SetActive(true);
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnWinConditionReady -= EnableWinObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            forest.SetActive(false);
            construction.SetActive(true);
            DayMode.SetActive(false);
            RenderSettings.skybox = skyBoxMat;
        }
    }
}
