using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassDoor : MonoBehaviour
{
    public string snakeTag = "Snake";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(snakeTag))
        {
            SnakeDataSource.score++;
            Destroy(other.gameObject);
        }
    }
}