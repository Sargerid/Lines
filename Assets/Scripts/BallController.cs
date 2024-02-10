using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Respawn
    [SerializeField] private float gravity;
    [SerializeField] Transform startPosition;
    //Swap Color
    public  bool isRed = false;
    public  bool isBlue = false;
    //Components
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.gravityScale = gravity;
            rb.freezeRotation = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToSpawnPosition();
        }
    }

     void ToSpawnPosition()
    {
        transform.position = startPosition.position;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        rb.rotation = 0;
        rb.freezeRotation = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            ToSpawnPosition();
        }

        if (other.CompareTag("RedSphere"))
        {
            isRed = true;
            isBlue = false;
            sr.color = Color.red;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("BlueSphere"))
        {
            isBlue = true;
            isRed = false;
            sr.color=Color.blue;
            Destroy(other.gameObject);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("RedWall"))
        {
            if (isRed && !isBlue)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.collider.CompareTag("BlueWall"))
        {
            if (isBlue && !isRed)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.collider.CompareTag("Death"))
        {
            ToSpawnPosition();
        }
    }
}
