using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineController : MonoBehaviour
{
    [SerializeField] Animator _anim;

    bool canMove;

    void Awake()
    {
        //_anim.speed = 0;
        PlayManager.Instance.SetEventsState(false);
    }
    void Start()
    {
        FirstView();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _anim.Play("CamPlayer");
            PlayManager.Instance.SetEventsState(true);
        }
    }

    public void CatcherView()
    {
        _anim.Play("CatcherView");
        PlayManager.Instance.SetEventsState(false);
        PlayManager.Instance.SetGamePlayState(false);
        StartCoroutine(ViewFruit(6f));

    }
    public void FlyingView()
    {
        _anim.Play("FlyingView");
        PlayManager.Instance.SetEventsState(false);
        PlayManager.Instance.SetGamePlayState(false);
        StartCoroutine(ReturnToPlayerCam(6f));

    }

    IEnumerator ViewFruit(float delay)
    {
        yield return new WaitForSeconds(delay);
        _anim.Play("FruitView");
        PlayManager.Instance.SetEventsState(true);
        StartCoroutine(ReturnToPlayerCam(4f));
        canMove = true;
    }
    IEnumerator ReturnToPlayerCam(float delay)
    {
        yield return new WaitForSeconds(delay);
        _anim.Play("CamPlayer");
        if (canMove)
        {
            PlayManager.Instance.SetGamePlayState(true);
        }
    }

    IEnumerator FirstPlayerView(float delay)
    {
        yield return new WaitForSeconds(delay);
        _anim.Play("FirstPlayerView");
        PlayManager.Instance.ActivateAnimation(true);
        yield return new WaitForSeconds(delay + 2f);
        PlayManager.Instance.SetEventsState(true);
    }

    public void FirstView()
    {
        PlayManager.Instance.SetGamePlayState(false);
        StartCoroutine(FirstPlayerView(1f));
    }
}
