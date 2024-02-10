using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float bounceForce;
    [SerializeField] private bool isTriggered = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("isTriggered",isTriggered);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up *  bounceForce,ForceMode2D.Impulse);
            Invoke("TurnOffTrigger",1f);
        }
    }

    void TurnOffTrigger()
    {
        isTriggered = false;
    }
}
