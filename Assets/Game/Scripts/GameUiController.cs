using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using Game.Scripts.DataClass;
using RockPaperScissor;
using UnityEngine;
using UnityEngine.UI;

public class GameUiController : MonoBehaviour
{
    [Tooltip("Index 0 is to store the image reference of player 1, index 1 is to store the image reference of player 2")]
    public Image[] handGesturePlayer;

    public GameObject readyUI;
    
    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;

    private PlayerInfo[] players;

    public float countDownTimer = 3f;

    public static GameUiController instance;
    
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
        
        players = AirConsoleController.players;

    }

    public void ShowReadyUI()
    {
        readyUI.SetActive(true);
    }

    
}
