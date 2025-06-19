using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovetwo : MonoBehaviour
{
    Rigidbody _rigidbody;
    Transform _playerTransform;
    float _posH;
    float _posV;
    float _mouseRot;
    Vector3 _moveDirection;
    Vector3 _rotation;
    Vector3 _stopMove;

    Animator m_anim;

    [SerializeField] float _speedMov = 0;
    [SerializeField] float _speedRot = 6;

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

            return;
        }
        _posH = Input.GetAxisRaw("Horizontal");
        _posV = Input.GetAxis("Vertical");
        _mouseRot = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speedMov = 8;
        }

        _moveDirection = _playerTransform.forward * (_posV * _speedMov);
        _playerTransform.Rotate(0, _mouseRot * _speedRot, 0);
        //Debug.Log(_moveDirection);
        
        Animate(_posV);
        
    }
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveDirection.x, _moveDirection.y, _moveDirection.z);
    }

    void Animate(float v)
    {
        bool walking = v != 0f;

        m_anim.SetBool("IsWalking", walking);
    }
}
