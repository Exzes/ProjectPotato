using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineController : MonoBehaviour
{
    [SerializeField] Animator _anim;

    void Start()
    {
        _anim.Play("CamPlayer");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _anim.Play("CatcherView");
        }
    }

    public void CatcherView()
    {
        _anim.Play("CatcherView");
        PlayManager.Instance.SetGamePlayState(false);
        StartCoroutine(ReturnToPlayerCam(8f));
    }

    IEnumerator ReturnToPlayerCam(float delay)
    {
        yield return new WaitForSeconds(delay);
        _anim.Play("CamPlayer");
        PlayManager.Instance.SetGamePlayState(true);
    }
}
