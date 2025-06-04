using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rigidbody;
    Transform _playerTransform;
    float _posH;
    float _posV;
    Vector3 _moveDirection;
    Vector3 _stopMove;

    Animator m_anim;

    [SerializeField] float _speedMov = 0;
    [SerializeField] float _speedRot = 0;

    void Start()
    {
        m_anim = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = transform;

        _rigidbody.freezeRotation = true;

        
    }


    void Update()
    {
        if (!PlayManager.Instance.canPlayerMove)
        {
            _moveDirection = _stopMove;
            Animate(0,0);

            return;
        }    
        _posH = Input.GetAxis("Horizontal");
        _posV = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speedMov = 8;
        }

        _moveDirection = _playerTransform.forward * (_posV * _speedMov);


        _playerTransform.Rotate(0, _posH * _speedRot, 0);


        Animate(_posV, _posH);
        
    }
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveDirection.x, _rigidbody.velocity.y, _moveDirection.z);
    }

    void Animate(float v, float h)
    {
        bool walking = v != 0f || h != 0f;

        m_anim.SetBool("IsWalking", walking);
    }
}
