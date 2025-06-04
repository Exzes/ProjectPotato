using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPresentation : MonoBehaviour
{
    [SerializeField] CineMachineController ShotChange;
    bool notFirstTime;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && notFirstTime == false)
        {

            var anim = ShotChange.GetComponent<CineMachineController>();
            anim.FlyingView();
            notFirstTime = true;

        }
    }
}
