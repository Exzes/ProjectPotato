using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPhisicsInt : MonoBehaviour
{
    [SerializeField] private float _forceMagnitude;
    void Update()
    {

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * _forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
