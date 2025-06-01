using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioMixer audioMixer;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        LoadVolumes();
    }
    public void ManageGenVol(float vol)
    {
        audioMixer.SetFloat("GeneralVol", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("VolGen", vol);
        PlayerPrefs.Save();
        //Debug.Log(vol);
    }
    public void ManageMusicVol(float vol)
    {
        audioMixer.SetFloat("MusicVol", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("VolMusic", vol);
        PlayerPrefs.Save();
    }
    public void ManageFXsVol(float vol)
    {
        
        audioMixer.SetFloat("FXsVol", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("VolFXs", vol);
        PlayerPrefs.Save();
    }

    public void LoadVolumes()
    {
        float genVol = PlayerPrefs.GetFloat("VolGen", 0.75f);
        float musicVol = PlayerPrefs.GetFloat("VolMusic", 0.75f);
        float fxVol = PlayerPrefs.GetFloat("VolFXs", 0.75f);
    }
}
