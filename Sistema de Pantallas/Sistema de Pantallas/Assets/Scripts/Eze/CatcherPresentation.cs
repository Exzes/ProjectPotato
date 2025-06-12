using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherPresentation : MonoBehaviour
{
    [SerializeField] CineMachineController ShotChange;
    PlayManager playManager;
    bool notFirstTime;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Catcher") && notFirstTime == false)
        {

            var anim = ShotChange.GetComponent<CineMachineController>();
            anim.CatcherView();
            notFirstTime = true;

        }
    }
}
