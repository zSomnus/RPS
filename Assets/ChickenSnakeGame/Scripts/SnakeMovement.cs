using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeDataSource))]
public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Vector2 moveDirection;

    private SnakeDataSource snakeDataSource;

    private void Awake()
    {
        snakeDataSource = GetComponent<SnakeDataSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (snakeDataSource.liveStatus == LiveStatus.ALIVE)
        {
            transform.Translate(moveDirection * (moveSpeed * Time.deltaTime));
        }
    }
}