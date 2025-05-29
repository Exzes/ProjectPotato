using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rigidbody;
    Transform _playerTransform;
    float _posH;
    float _posV;
    float _gravity = -9.8f;
    bool _isGrounded;
    Vector3 _moveDirection;

    Animator m_anim;

    [SerializeField] float _speedMov = 0;
    [SerializeField] float _speedRot = 0;

    void Start()
    {
        m_anim = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = transform;

        _rigidbody.freezeRotation = true;
        _rigidbody.useGravity = false;
        
    }


    void Update()
    {
        _posH = Input.GetAxis("Horizontal");
        _posV = Input.GetAxis("Vertical");

        _playerTransform.Rotate(0, _posH * _speedRot * Time.deltaTime, 0);

        _moveDirection = _playerTransform.forward * _posV * _speedMov;
        _moveDirection.y = _rigidbody.velocity.y;

        if (!_isGrounded)
        {
            _moveDirection.y += _gravity * Time.deltaTime;
        }

        Animate(_posV);
        
    }
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveDirection.x, _rigidbody.velocity.y, _moveDirection.z);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            _isGrounded = true;
        }
    }

    void OollisionExit(Collision collision)
    {
        _isGrounded = false;
    }

    void Animate(float v)
    {
        bool walking = v != 0f;

        m_anim.SetBool("IsWalking", walking);
    }
}
