using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffectController : MonoBehaviour
{
    [SerializeField] PostProcessVolume volume;
    //[SerializeField] PostProcessProfile normalProfile;
    //[SerializeField] PostProcessProfile sepiaProfile;
    [SerializeField] float transitionSpeed = 2f;

    float targetWeight = 0f;

    void Update()
    {
        if (volume != null)
        {
            volume.weight = Mathf.Lerp(volume.weight, targetWeight, Time.deltaTime * transitionSpeed);
        }
    }
    public void ApplySepia()
    {
        targetWeight = 1;
    }

    public void RemoveSepia()
    {
        targetWeight = 0;
    }
}
