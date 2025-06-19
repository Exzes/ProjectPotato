using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleThirdPersonMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 90f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita que la física lo rote
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D
        float vertical = Input.GetAxisRaw("Vertical");     // W/S

        // Rotar con A y D
        transform.Rotate(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);

        // Mover hacia adelante/atrás
        Vector3 direction = transform.forward * vertical * moveSpeed;
        rb.velocity = new Vector3(direction.x, rb.velocity.y, direction.z);
    }
}

