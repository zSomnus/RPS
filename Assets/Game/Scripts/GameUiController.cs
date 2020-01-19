using System;
using Game.Scripts.DataClass;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class GameUiController : MonoBehaviour
    {
        [Tooltip("Index 0 is to store the image reference of player 1, index 1 is to store the image reference of player 2")]
        public Image[] handGesturePlayer;

        public GameObject readyUI;
    
        public Sprite rock;
        public Sprite paper;
        public Sprite scissors;


        public float countDownTimer = 3f;

        public static GameUiController instance;

        public TextMeshProUGUI[] playerScoreTexts;
    
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
        

        }

        private void Update()
        {
            for (int i = 0; i < AirConsoleController.players.Length; i++)
            {
                playerScoreTexts[i].text =$"{AirConsoleController.players[i].healthPoint}";
            }
        }

        public void ShowReadyUI(bool isReady)
        {
            readyUI.SetActive(isReady);
        }

    
    }
}
