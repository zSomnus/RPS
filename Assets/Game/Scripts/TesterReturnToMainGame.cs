using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;

public class TesterReturnToMainGame : MonoBehaviour
{
    private PlayerInputActions inputAction;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.Test.BackToMainGame.performed += ctx => BackToMainGame();
    }

    public void BackToMainGame()
    {
        print("Back to main game");
        AirConsoleController.instance.miniGameOutputData = new MiniGameOutputData(AirConsoleController.players[0], 10);
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        levelLoader.LoadMainGame();
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
