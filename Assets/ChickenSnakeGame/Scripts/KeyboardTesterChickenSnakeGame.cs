using System;
using UnityEngine;

namespace ChickenSnakeGame.Scripts
{
    public class KeyboardTesterChickenSnakeGame : MonoBehaviour
    {
        public ChickenMovement movement;

        private PlayerInputActions inputAction;

        private void Awake()
        {
            inputAction = new PlayerInputActions();
            inputAction.MiniGameControls.Chicken.performed += ctx => MoveChickenHeadDown();
            inputAction.MiniGameControls.Viper.performed += ctx => SpawnSnake();
            print("Initialize input action");
        }


        private void MoveChickenHeadDown()
        {
            print("Move chicken");
            movement.SwitchState(ChickenMovementState.MOVETODESTINATION);
        }

        private void SpawnSnake()
        {
            Spawner.instance.Spawn();
        }

        private void OnEnable()
        {
            inputAction.Enable();
        }

        private void OnDisable()
        {
            inputAction.Disable();
        }
    }
}
