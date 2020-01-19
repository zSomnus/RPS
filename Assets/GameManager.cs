using System;
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
        var message = data["action"].ToString();
        switch (message)
        {
            case "Rock":
                player.handGesture = HandGesture.Rock;
                break;
            case "Paper":
                player.handGesture = HandGesture.Paper;
                break;
            case "Scissors":
                player.handGesture = HandGesture.Scissors;
                break;
            default:
                Debug.LogError($"Don't know how to process the command {message}");
                break;
        }

        onPlayerStateChanged?.Invoke();
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
            levelLoader.LoadMinigame();
        }
        else
        {
            CardGenerator.instance.ClearBoard();
            print("Board is cleared");
            state = GameState.CardSelect;
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

    public IEnumerator FlipCards(float sec)
    {
        yield return new WaitForSeconds(sec);
        FlipCards();
    }

    public void FlipCards()
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
    public MiniGameInputData Judge()
    {
        MiniGameInputData result = null;
        if (AirConsoleController.players[0].handGesture == AirConsoleController.players[1].handGesture)
        {
            print("It is a draw");
            return null;
        }
        else
        {
            if (AirConsoleController.players[0].handGesture == HandGesture.Paper)
            {
                if (AirConsoleController.players[1].handGesture == HandGesture.Rock)
                {
                    result = new MiniGameInputData(AirConsoleController.players[0],AirConsoleController.players[1]);
                    AirConsoleController.players[1].healthPoint--;
                }
                else
                {
                    result = new MiniGameInputData(AirConsoleController.players[1],AirConsoleController.players[0]);

                    AirConsoleController.players[0].healthPoint--;
                }
            }

            if (AirConsoleController.players[0].handGesture == HandGesture.Scissors)
            {
                if (AirConsoleController.players[1].handGesture == HandGesture.Paper)
                {
                    result = new MiniGameInputData(AirConsoleController.players[0],AirConsoleController.players[1]);

                    AirConsoleController.players[1].healthPoint--;
                }
                else
                {
                    result = new MiniGameInputData(AirConsoleController.players[1],AirConsoleController.players[0]);

                    AirConsoleController.players[0].healthPoint--;
                }
            }

            if (AirConsoleController.players[0].handGesture == HandGesture.Rock)
            {
                if (AirConsoleController.players[1].handGesture == HandGesture.Scissors)
                {
                    result = new MiniGameInputData(AirConsoleController.players[0],AirConsoleController.players[1]);

                    AirConsoleController.players[1].healthPoint--;
                }
                else
                {
                    result = new MiniGameInputData(AirConsoleController.players[1],AirConsoleController.players[0]);

                    AirConsoleController.players[0].healthPoint--;
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