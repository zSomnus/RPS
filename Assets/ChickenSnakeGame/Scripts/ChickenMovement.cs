using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField] private float moveUpSpeed = 20f;

    [SerializeField] private float moveDownSpeed = 10f;

    [SerializeField] private Transform origin;
    [SerializeField] private Transform destination;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Timer moveBacktimer;

    private ChickenMovementState moveState = ChickenMovementState.IDLE;

    private void Awake()
    {
        moveBacktimer = gameObject.AddComponent<Timer>();
        moveBacktimer.SetUp(2);
        moveBacktimer.OnTimerStop += MoveBack;
    }
    
    // Start is called before the first frame update
    void Start()
    {

        startPosition = origin.position;
        endPosition = destination.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveState)
        {
            case ChickenMovementState.MOVETOORIGIN:
                
                if (Vector2.Distance(transform.position, startPosition) >= 0.04f)
                {
                    transform.Translate((startPosition-transform.position).normalized * (moveUpSpeed * Time.deltaTime));
                }
                else
                {
                    moveState = ChickenMovementState.IDLE;
                }
                break;
            case ChickenMovementState.MOVETODESTINATION:
                if (Vector2.Distance(transform.position, endPosition) >= 0.04f)
                {
                    transform.Translate((endPosition-transform.position).normalized * (moveDownSpeed * Time.deltaTime));
                }
                else
                {
                    moveBacktimer.Run();
                }
                break;
            case ChickenMovementState.IDLE:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void MoveBack()
    {
        moveState = ChickenMovementState.MOVETOORIGIN;

    }

    public void SwitchState(ChickenMovementState newState)
    {
        if (moveState == ChickenMovementState.IDLE)
        {
            moveState = newState;
        }
        else
        {
            Debug.LogError("Chicken is still moving, can't change state now");
        }
    }
}

public enum ChickenMovementState
{
    MOVETOORIGIN, MOVETODESTINATION, IDLE
}