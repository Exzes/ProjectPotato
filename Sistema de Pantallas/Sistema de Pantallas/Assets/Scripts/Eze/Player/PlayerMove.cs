using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleThirdPersonMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 90f;

    private Rigidbody rb;
    Animator m_anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        float _posH = Input.GetAxisRaw("Horizontal");
        float _posV = Input.GetAxisRaw("Vertical");

        // Rotar con A y D
        transform.Rotate(0f, _posH * rotationSpeed * Time.deltaTime, 0f);

        // Mover hacia adelante/atrás
        Vector3 direction = transform.forward * _posV * moveSpeed;
        rb.velocity = new Vector3(direction.x, rb.velocity.y, direction.z);
        Animate(_posV);
    }

    void Animate(float v)
    {
        bool walking = v != 0f;

        m_anim.SetBool("IsWalking", walking);
    }
}

