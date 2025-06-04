using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineController : MonoBehaviour
{
    [SerializeField] Animator _anim;

    void Start()
    {
        _anim.Play("CamPlayer");
        PlayManager.Instance.SetGamePlayState(false);
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
        PlayManager.Instance.SetEventsState(false);
        StartCoroutine(ViewFruit(6f));
        
    }
    public void FlyingView()
    {
        _anim.Play("FlyingView");
        PlayManager.Instance.SetEventsState(false);
        StartCoroutine(ReturnToPlayerCam(6f));
        
    }

    IEnumerator ViewFruit(float delay)
    {
        yield return new WaitForSeconds(delay);
        _anim.Play("FruitView");
        PlayManager.Instance.SetEventsState(true);
        StartCoroutine(ReturnToPlayerCam(4f));
    }
    IEnumerator ReturnToPlayerCam(float delay)
    {
        yield return new WaitForSeconds(delay);
        _anim.Play("CamPlayer");
        PlayManager.Instance.SetGamePlayState(true);
    }
}
