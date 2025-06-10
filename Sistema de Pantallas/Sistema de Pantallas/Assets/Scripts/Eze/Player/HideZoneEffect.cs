using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideZoneEffect : MonoBehaviour
{
    [SerializeField]CameraEffectController cameraEffect;
    int hidingZoneCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "HidingArea")
        {
            hidingZoneCount++;
            if (hidingZoneCount == 1)
            {
                cameraEffect.ApplySepia();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "HidingArea")
        {
            hidingZoneCount--;
            hidingZoneCount = Mathf.Max(hidingZoneCount, 0);

            if (hidingZoneCount == 0)
            {
                cameraEffect.RemoveSepia();
            }
        }
    }
}
