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

    public void DisplayPlayerHandGesture()
    {
        if (players.Length != handGesturePlayer.Length)
        {
            Debug.LogError("players length should be the same as hand gesture player's length");
        }
        for (int i = 0; i < players.Length; i++)
        {
            switch (players[i].handGesture)
            {
                case HandGesture.Paper:
                    handGesturePlayer[i].sprite = paper;
                    break;
                case HandGesture.Rock:
                    handGesturePlayer[i].sprite = rock;
                    break;
                case HandGesture.Scissors:
                    handGesturePlayer[i].sprite = scissors;
                    break;
            }
        }
    }
    
    public void ShowReadyUI()
    {
        readyUI.SetActive(true);
        StartCoroutine(DisplayPlayerHandGestureDelay(countDownTimer));
    }

    IEnumerator DisplayPlayerHandGestureDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        DisplayPlayerHandGesture();
    }
}
