using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeDataSource))]
public class SnakeDestroyer : MonoBehaviour
{
    private SnakeDataSource snakeDataSource;

    private void Awake()
    {
        snakeDataSource = GetComponent<SnakeDataSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag($"Chicken"))
        {
            print("hit chicken");
            snakeDataSource.liveStatus = LiveStatus.DEAD;
            foreach (var snakePiece in snakeDataSource.brokenPieces)
            {
                Instantiate(snakePiece, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            SnakeDataSource.lives--;
            print(SnakeDataSource.lives);
        }

    }
}