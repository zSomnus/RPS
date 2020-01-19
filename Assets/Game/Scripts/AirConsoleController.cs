using Game.Scripts.DataClass;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Scripts
{
    public class AirConsoleController : MonoBehaviour
    {
        public static PlayerInfo[] players;

        [Tooltip("This html is used to display the interface shown for the main game ")]
        public Object gameControllerHtml;

        public delegate void simpleEventHandler(PlayerInfo[] players);

        public static event simpleEventHandler onPlayerChanged;

        public static AirConsoleController instance;

        public MiniGameInputData miniGameInputData;
        public MiniGameOutputData miniGameOutputData;
        

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
            
            players = new PlayerInfo[2];
            AirConsole.instance.onMessage += OnMessage;
            AirConsole.instance.onConnect += OnConnect;
            AirConsole.instance.onDisconnect += OnDisconnect;
            
        }

        private void OnMessage(int @from, JToken data)
        {
            print($"Message from {from}, data: "+data["action"]);
        }

        private void OnDisconnect(int device_id)
        {
            
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].deviceId == device_id)
                {
                    players[i] = null;
                }
            }
            onPlayerChanged?.Invoke(players);
        }

        private void OnConnect(int device_id)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == null)
                {
                    players[i] = new PlayerInfo(device_id, i);
                    break;
                }
            }
            onPlayerChanged?.Invoke(players);
        }

        public static PlayerInfo GetPlayerWithDeviceId(int deviceId)
        {
            foreach (PlayerInfo player in players)
            {
                if (player.deviceId == deviceId)
                {
                    return player;
                }
            }

            return null;
        }

        /// <summary>
        /// Check if all the players have ready to play
        /// </summary>
        /// <returns></returns>
        public static bool playersAreReady()
        {
            foreach (PlayerInfo player in players)
            {
                if (!player.ready)
                {
                    return false;
                }
            }

            return true;
        }

        public void SwitchUI()
        {
            AirConsole.instance.controllerHtml = gameControllerHtml;
        }

        /// <summary>
        /// return "Player State not equal to pending"
        /// </summary>
        /// <returns></returns>
        public bool PlayersMadeMoves()
        {
            foreach (PlayerInfo player in players)
            {
                if (player.handGesture == HandGesture.Pending)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckIfAllPlayersReady()
        {
            foreach (PlayerInfo player in players)
            {
                if (player.handGesture == HandGesture.Pending)
                    return false;
            }

            return true;
        }
    }
}
