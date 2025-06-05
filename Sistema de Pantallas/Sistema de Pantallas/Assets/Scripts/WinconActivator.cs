using UnityEngine;

public class WinConditionActivator : MonoBehaviour
{
    [SerializeField] private GameObject extractionZone;

    private void Start()
    {
        extractionZone.SetActive(false);
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
}