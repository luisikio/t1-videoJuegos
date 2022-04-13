using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 10;
    public float jumpForce = 10;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    private static readonly int Animation_run=0;
    private static readonly int Animation_Jump = 1;
    private static readonly int Animation_Dead = 2;
   // private static readonly int fin = 4;

    private int temp = 0;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (temp!=1)
        {
            _rigidbody2D.velocity = new Vector2(velocidad,_rigidbody2D.velocity.y);
            ChangeAnimation(Animation_run);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _rigidbody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
                
                ChangeAnimation(Animation_Jump);
            }
        }
        if (temp==1)
        {
            ChangeAnimation(Animation_Dead);
            _rigidbody2D.velocity = new Vector2(0,_rigidbody2D.velocity.y);
           
        }
    }

    private void ChangeAnimation(int Animation)
    {
        _animator.SetInteger("Estado",Animation);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var tag = other.gameObject.tag;
        Debug.Log(tag);
        if (tag=="zombie")
        {
            temp = 1;
            Application.Quit();
        }
    }
}
