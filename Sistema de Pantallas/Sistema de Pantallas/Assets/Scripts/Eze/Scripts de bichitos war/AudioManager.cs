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
        audioMixer.SetFloat("masterVol", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("VolMaster", vol);
        PlayerPrefs.Save();
        //Debug.Log(vol);
    }
    public void ManageMusicVol(float vol)
    {
        audioMixer.SetFloat("bgmVol", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("VolBGM", vol);
        PlayerPrefs.Save();
    }
    public void ManageFXsVol(float vol)
    {
        
            Debug.Log("FX Vol Changed: " + vol);
        audioMixer.SetFloat("sfxVol", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("VolSFX", vol);
        PlayerPrefs.Save();
    }

    public void LoadVolumes()
    {
        float masterVol = PlayerPrefs.GetFloat("VolMaster", 0.75f);
        float bgmVol = PlayerPrefs.GetFloat("VolBGM", 0.75f);
        float sfxVol = PlayerPrefs.GetFloat("VolSFX", 0.75f);
    }
}
