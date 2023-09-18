using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move: MonoBehaviour
{
    public CharacterController2D controller;
    public float MovementSpeed = 1;
    public float Jumpforce = 1;
    public Animator animator;

    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        animator.SetFloat("Speed", Mathf.Abs(movement));

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if(Input.GetButtonDown("Jump")&& Mathf.Abs(_rigidbody.velocity.y)<0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
            
        }

    }
   
    }

