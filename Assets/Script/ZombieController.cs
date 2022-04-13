using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce = 10;
    private Rigidbody2D _rigidbody2D;

    private bool salto=false;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        salto = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (salto==true)
        {
            _rigidbody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
        }

        if (salto==false)
        {
            _rigidbody2D.AddForce(Vector2.up*0,ForceMode2D.Impulse);
            _rigidbody2D.gravityScale = 1;

        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var tag = other.gameObject.tag;
        Debug.Log(tag);
        if (tag=="suelo")
        {
            salto = true;
        }

        if (tag=="techo")
        {
            salto = false;
        }
    }
}
