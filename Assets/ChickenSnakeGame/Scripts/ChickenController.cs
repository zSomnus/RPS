using System;
using UnityEngine;

[RequireComponent(typeof(ChickenMovement))]
public class ChickenController : MonoBehaviour
{

    private ChickenMovement movement;

    private void Awake()
    {
        movement = GetComponent<ChickenMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement.SwitchState(ChickenMovementState.MOVETODESTINATION);
        }

        
    }
}
