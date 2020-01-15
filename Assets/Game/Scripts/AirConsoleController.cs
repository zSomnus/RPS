using System;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace RockPaperScissor
{
    public class AirConsoleController : MonoBehaviour
    {
        public static PlayerInfo[] players;


        public delegate void simpleEventHandler(PlayerInfo[] players);

        public static event simpleEventHandler onPlayerChanged;
        

        private void Awake()
        {
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

    }
}
