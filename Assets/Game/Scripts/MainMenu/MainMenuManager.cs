using System;
using System.Collections;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using RockPaperScissor;
using UnityEngine;

namespace MainGame.Scripts.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuManager instance;

        [Tooltip("The time to transfer to the next scene after all players are ready")]
        public float countDownTime = 3f;
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
            
            AirConsole.instance.onMessage += OnMessage;
        }

        private void OnMessage(int @from, JToken data)
        {
            if (String.Compare(data["action"].ToString(), "Ready", StringComparison.Ordinal) == 0)
            {
                var ReadyPlayer = AirConsoleController.GetPlayerWithDeviceId(from);
                ReadyPlayer.ready = !ReadyPlayer.ready;
                MainMenuUiController.instance.UpdatePlayerReadyText();

                if (AirConsoleController.playersAreReady())
                {
                    StartCoroutine(StartGame());
                    
                }
                else
                {
                    StopAllCoroutines();
                }
            }
        }

        IEnumerator StartGame()
        {
            yield return new WaitForSeconds(3);
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            levelLoader.LoadNextLevel();
        }

    }
}
