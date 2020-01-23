using System;
using System.Collections;
using MainGame.Scripts.MainMenu;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Game.Scripts.MainMenu
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
                    StartCoroutine(LoadMainGame());
                }
                else
                {
                    StopAllCoroutines();
                }
            }
        }

        IEnumerator LoadMainGame()
        {
            yield return new WaitForSeconds(3);
            AirConsole.instance.Broadcast("Ready");
            AirConsoleController.instance.SwitchUI();
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            levelLoader.LoadNextLevel();
        }

    }
}
