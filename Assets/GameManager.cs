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

    
    public delegate void PlayerHandler();
    public event PlayerHandler onPlayerStateChanged;
    
    private void Awake()
    {
        onPlayerStateChanged += TryUpdateReadyUI;
        onPlayerStateChanged += TryGeneratePlayerCard;
        onPlayerStateChanged += TryFlipCardIfPlayerReady;
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
        AirConsole.instance.onMessage += OnMessage;
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
    

    
}
