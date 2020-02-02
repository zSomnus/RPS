using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSnake : MonoBehaviour
{
    [SerializeField] private float idealExistedTime = 3;
    private float existedTime;

    private void Start()
    {
        existedTime = idealExistedTime;
    }

    private void Update()
    {
        if (existedTime > 0)
        {
            existedTime -= Time.deltaTime;
            if (existedTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
