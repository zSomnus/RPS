﻿using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using Game.Scripts.DataClass;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // State
    public GameState state;

    // reference 

    public delegate void PlayerHandler();

    public event PlayerHandler onPlayerStateChanged;

    private void Awake()
    {
        onPlayerStateChanged += TryUpdateReadyUI;
        onPlayerStateChanged += TryGeneratePlayerCard;
        onPlayerStateChanged += TryFlipCardIfPlayerReady;
        AirConsole.instance.onMessage += OnMessage;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        if (AirConsoleController.instance.miniGameOutputData != null)
        {
            BackFromMinigame();
        }

        state = GameState.CardSelect;
    }


    /// <summary>
    /// Receive user button click
    /// </summary>
    /// <param name="from"></param>
    /// <param name="data"></param>
    private void OnMessage(int @from, JToken data)
    {
        var player = AirConsoleController.GetPlayerWithDeviceId(from);
        var message = data.ToString();
        print($"Message sent is {message}");
        Debug.Log(from);
        switch (data["action"].ToString())
        {
            case "viper":
                player.handGesture = HandGesture.Viper;
                instance.TryGeneratePlayerCard();
                instance.TryFlipCardIfPlayerReady();
                break;
            case "chicken":
                player.handGesture = HandGesture.Chicken;
                instance.TryGeneratePlayerCard();
                instance.TryFlipCardIfPlayerReady();
                break;
            case "fox":
                player.handGesture = HandGesture.Fox;
                instance.TryGeneratePlayerCard();
                instance.TryFlipCardIfPlayerReady();
                break;
            case "accepted":
                TryGeneratePlayerCard();
                TryFlipCardIfPlayerReady();
                break;
            default:
                Debug.LogError($"Don't know how to process the command {message}");
                break;
        }

    }

    private void Update()
    {
        if (state == GameState.Judge)
        {
            StartCoroutine(JudgeAndRestartGame());
        }
    }

    public IEnumerator JudgeAndRestartGame()
    {
        MiniGameInputData miniGameInputData = Judge();
        state = GameState.DisplayResult;

        yield return new WaitForSeconds(3);

        
        // The game has a winner
        if (miniGameInputData != null)
        {
            state = GameState.MiniGame;
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            AirConsoleController.instance.miniGameInputData = miniGameInputData;    // TODO 
            print("Loading scene "+miniGameInputData.miniGameSceneIndex);
            levelLoader.LoadMinigame(miniGameInputData.miniGameSceneIndex);
        }
        else
        {
            CardGenerator.instance.ClearBoard();
            print("Board is cleared");
            state = GameState.CardSelect;
            AirConsole.instance.Broadcast("Reset");
        }
       
    }

    public void BackFromMinigame()
    {
        AirConsoleController.instance.miniGameOutputData.playerReceiveDamage.healthPoint -=
            AirConsoleController.instance.miniGameOutputData.damage;
        CardGenerator.instance.ClearBoard();
        print("Board is cleared");
        state = GameState.CardSelect;
    }


    public void TryUpdateReadyUI()
    {
        GameUiController.instance.ShowReadyUI(AirConsoleController.instance.CheckIfAllPlayersReady() &&
                                              state == GameState.CardSelect);
    }

    public void TryGeneratePlayerCard()
    {
        foreach (PlayerInfo player in AirConsoleController.players)
        {
            CardGenerator.instance.GenerateCardForPlayer(player);
        }
    }

    public void TryFlipCardIfPlayerReady()
    {
        if (AirConsoleController.instance.CheckIfAllPlayersReady())
        {
            StartCoroutine(FlipCards(3));
        }
    }

    private IEnumerator FlipCards(float sec)
    {
        yield return new WaitForSeconds(sec);
        FlipCards();
    }

    private void FlipCards()
    {
        state = GameState.FilpCard;
        CardFlip p1Card = CardGenerator.instance.cardPositionPlayers[0].GetComponentInChildren<CardFlip>();
        CardFlip p2Card = CardGenerator.instance.cardPositionPlayers[1].GetComponentInChildren<CardFlip>();

        if (p1Card != null)
            p1Card.Flip();
        if (p2Card != null)
            p2Card.Flip();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>The player who wins</returns>
    private MiniGameInputData Judge()
    {
        MiniGameInputData result = null;
        if (AirConsoleController.players[0].handGesture == AirConsoleController.players[1].handGesture)
        {
            print("It is a draw");
            AirConsole.instance.Broadcast("Draw");
            return null;
        }
        else
        {
            if (AirConsoleController.players[0].handGesture == HandGesture.Chicken)
            {
                if (AirConsoleController.players[1].handGesture == HandGesture.Viper)
                {
                    result = new MiniGameInputData(AirConsoleController.players[0],AirConsoleController.players[1], MiniGameSceneDataSource.ChickenSnakeGame);
                    AirConsoleController.players[1].healthPoint--;
                    AirConsole.instance.Broadcast("P1Win");
                }
                else
                {
                    result = new MiniGameInputData(AirConsoleController.players[1],AirConsoleController.players[0], MiniGameSceneDataSource.FoxChickenGameScene);

                    AirConsoleController.players[0].healthPoint--;
                    AirConsole.instance.Broadcast("P2Win");
                }
            }

            if (AirConsoleController.players[0].handGesture == HandGesture.Fox)
            {
                if (AirConsoleController.players[1].handGesture == HandGesture.Chicken)
                {
                    result = new MiniGameInputData(AirConsoleController.players[0],AirConsoleController.players[1], MiniGameSceneDataSource.FoxChickenGameScene);

                    AirConsoleController.players[1].healthPoint--;
                    AirConsole.instance.Broadcast("P1Win");

                }
                else
                {
                    result = new MiniGameInputData(AirConsoleController.players[1],AirConsoleController.players[0], MiniGameSceneDataSource.SnakeFoxGameScene);

                    AirConsoleController.players[0].healthPoint--;
                    AirConsole.instance.Broadcast("P2Win");

                }
            }

            if (AirConsoleController.players[0].handGesture == HandGesture.Viper)
            {
                if (AirConsoleController.players[1].handGesture == HandGesture.Fox)
                {
                    result = new MiniGameInputData(AirConsoleController.players[0],AirConsoleController.players[1], MiniGameSceneDataSource.SnakeFoxGameScene);

                    AirConsoleController.players[1].healthPoint--;
                    AirConsole.instance.Broadcast("P1Win");

                }
                else
                {
                    result = new MiniGameInputData(AirConsoleController.players[1],AirConsoleController.players[0], MiniGameSceneDataSource.ChickenSnakeGame);

                    AirConsoleController.players[0].healthPoint--;
                    AirConsole.instance.Broadcast("P2Win");

                }
            }
        }

        return result;
    }
}

public enum GameState
{
    CardSelect,
    FilpCard,
    Judge,
    DisplayResult,
    MiniGame,
    End
}