using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    private Transform visual;

    void Awake()
    {
        visual = transform.GetChild(0);
    }

    public void ResetFruta()
    {
        visual.localPosition = Vector3.zero;
        visual.localRotation = Quaternion.identity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Fruta recogida");
            gameObject.SetActive(false);
            GameStateManager.Instance.CollectFruit();
            FruitScoreManager.Instance.AddFruitAmount(1);
        }
    }
}
