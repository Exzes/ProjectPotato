using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineController : MonoBehaviour, IAnimationState
{
    [SerializeField] Animator _anim;

    void Awake()
    {
        PlayManager.Instance.SetGamePlayState(false);
        PlayManager.Instance.SetEventsState(false);
        PauseSceneAnimation();
    }
    void Start()
    {
        _anim.Play("AerialCloseUp");
        if (_anim.speed == 1)
        {
            _anim.Play("CamPlayer");
        }
        
    }
    public void StartSceneAnimation()
    {
        _anim.speed = 1f;
    }
    public void PauseSceneAnimation()
    {
        _anim.speed = 0f;
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
        yield return new WaitForSeconds(delay + 2f);
        PlayManager.Instance.SetGamePlayState(true);
        PlayManager.Instance.SetEventsState(true);
    }
}
