using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using Game.Scripts.DataClass;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using RockPaperScissor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // State
    public GameState state;
    
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
            state = GameState.CardSelect;
            StartCoroutine(JudgeAndRestartGame());
        }
    }

    public IEnumerator JudgeAndRestartGame()
    {
        Judge();

        yield return new WaitForSeconds(3);
            
        CardGenerator.instance.ClearBoard();
        print("Board is cleared");
    }


    private void TryUpdateReadyUI()
    {
        if (AirConsoleController.instance.CheckIfAllPlayersReady())
        {
            GameUiController.instance.ShowReadyUI();
        }
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
        CardFlip p1Card = CardGenerator.instance.cardPositionPlayers[0].GetComponentInChildren<CardFlip>();
        CardFlip p2Card = CardGenerator.instance.cardPositionPlayers[1].GetComponentInChildren<CardFlip>();

        if (p1Card != null)
            p1Card.Flip();
        if(p2Card != null)
            p2Card.Flip();
    }

    public void Judge()
    {
        if (AirConsoleController.players[0].handGesture == AirConsoleController.players[1].handGesture)
        {
            print("fair");
        }
        else
        {
            if (AirConsoleController.players[0].handGesture == HandGesture.Paper)
            {
                if (AirConsoleController.players[1].handGesture == HandGesture.Rock)
                {
                    print("player 1 wins");
                }
                else
                {
                    print("player 2 wins");
                }
            }

            if (AirConsoleController.players[0].handGesture == HandGesture.Scissors)
            {
                if (AirConsoleController.players[1].handGesture == HandGesture.Paper)
                {
                    print("player 1 wins");
                }
                else
                {
                    print("player 2 wins");
                }
            }

            if (AirConsoleController.players[0].handGesture == HandGesture.Rock)
            {
                if (AirConsoleController.players[1].handGesture == HandGesture.Scissors)
                {
                    print("player 1 wins");
                }
                else
                {
                    print("player 2 wins");
                }
            }

        }

    }


}

public enum GameState
{
    CardSelect, Judge, MiniGame, End
}
