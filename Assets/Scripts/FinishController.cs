using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private float timeToStay;
    private float timer;
    private bool playerInside;

    private void Start()
    {
        timer = 0f;
        playerInside = false;
    }

    private void Update()
    {
        if (playerInside)
        {
            timer += Time.deltaTime;

            if (timer >= timeToStay)
            {
                SceneManager.LoadScene(levelName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            timer = 0f; 
        }
    }
}
