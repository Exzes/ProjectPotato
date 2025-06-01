using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public enum VolumeType {General, Music, FX}
    public VolumeType volumeType;
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        float defaultVol = 0.75f;
        switch(volumeType)
        {
            case VolumeType.General:
                defaultVol = PlayerPrefs.GetFloat("VolGen", 0.75f);
                break;
            case VolumeType.Music:
                defaultVol = PlayerPrefs.GetFloat("VolMusic", 0.75f);
                break;
            case VolumeType.FX:
                defaultVol = PlayerPrefs.GetFloat("VolFX", 0.75f);
                break;     
        }
        slider.value = defaultVol;
        slider.onValueChanged.AddListener(SetVolChange);
    }

    void SetVolChange(float value)
    {
        switch (volumeType)
        {
            case VolumeType.General:
                AudioManager.Instance.ManageGenVol(value);
                break;
            case VolumeType.Music:
                AudioManager.Instance.ManageMusicVol(value);
                break;
            case VolumeType.FX:
                AudioManager.Instance.ManageFXsVol(value);
                break;
        }
    }
}
