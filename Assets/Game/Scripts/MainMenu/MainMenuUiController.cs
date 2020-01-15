using Game.Scripts.DataClass;
using RockPaperScissor;
using UnityEngine;

namespace MainGame.Scripts.MainMenu
{
    public class MainMenuUiController : MonoBehaviour
    {
        public GameObject[] IconPlayerReadyIcons;
        public GameObject[] readyTexts;

        public GameObject countDownPanel;

        public static MainMenuUiController instance;
        private void Awake()
        {    
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
            AirConsoleController.onPlayerChanged += UpdateUi;
        }

    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateUi(PlayerInfo[] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] != null)
                {
                    IconPlayerReadyIcons[i].SetActive(true);
                }
                else
                {
                    IconPlayerReadyIcons[i].SetActive(false);
                }
            }
        
        }
    

        public void UpdatePlayerReadyText()
        {
            for (int i = 0; i < AirConsoleController.players.Length; i++)
            {
                if (AirConsoleController.players[i].ready)
                {
                    readyTexts[i].SetActive(true);
                }
                else
                {
                    readyTexts[i].SetActive(false);
                }
            }

            if (AirConsoleController.playersAreReady())
            {
                countDownPanel.SetActive(true);
            }
            else
            {
                countDownPanel.SetActive(false);
            }
        }
    }
}
