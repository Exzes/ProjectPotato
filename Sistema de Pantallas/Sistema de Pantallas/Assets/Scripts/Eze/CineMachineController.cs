using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineController : MonoBehaviour
{
    [SerializeField] Animator anim;

    void Start()
    {
        anim.Play("CamPlayer");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.Play("CamPlayer");
        }
    }
}
