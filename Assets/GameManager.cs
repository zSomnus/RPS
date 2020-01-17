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

    private void Awake()
    {
        onPlayerStateChanged += UpdateReadyUI;
        onPlayerStateChanged += TryGeneratePlayerCard;
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

    public delegate void PlayerHandler();
    public event PlayerHandler onPlayerStateChanged;
    

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


    private void UpdateReadyUI()
    {
        GameUiController.instance.ShowReadyUI();
    }

    private void TryGeneratePlayerCard()
    {
        foreach (PlayerInfo player in AirConsoleController.players)
        {
            CardGenerator.instance.GenerateCardForPlayer(player);
        }
    }
    

    
}
