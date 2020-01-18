using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.DataClass;
using RockPaperScissor;
using UnityEngine;

namespace Game.Scripts
{
    public class CardGenerator : MonoBehaviour
    {
        [Tooltip("Index 0 is for player 1, index 1 is for player 2")]
        public Transform[] cardPositionPlayers;

        private GameObject[] cardGenerated;
        public GameObject rockCard;
        public GameObject paperCard;
        public GameObject scissorsCard;
        public static CardGenerator instance;

        public Boo.Lang.List<GameObject> cardsInScene;

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
            
            cardsInScene = new Boo.Lang.List<GameObject>();
        }

        private void Start()
        {
            cardGenerated = new GameObject[2];
        }

        public void GenerateCardForPlayer(PlayerInfo player)
        {
            int playerIndex = player.index;
            
            // If player already select a card, then don't generate another card for the player
            if (cardGenerated[playerIndex])
            {
                return;
            }
            switch (player.handGesture)
            {
                case HandGesture.Pending:
                    break;
                case HandGesture.Paper:
                    cardGenerated[playerIndex] = Instantiate(paperCard, cardPositionPlayers[playerIndex]);
                    print("Generated paper for player "+playerIndex);
                    break;
                case HandGesture.Rock:
                    cardGenerated[playerIndex] = Instantiate(rockCard, cardPositionPlayers[playerIndex]);
                    print("Generated rock for player "+playerIndex);

                    break;
                case HandGesture.Scissors:
                    cardGenerated[playerIndex] = Instantiate(scissorsCard, cardPositionPlayers[playerIndex]);
                    print("Generated scissors for player "+playerIndex);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            
        }

        public void ClearBoard()
        {
            foreach (var card in cardGenerated)
            {
                Destroy(card);
            }
            cardGenerated = new GameObject[2];

            foreach (var player in AirConsoleController.players)
            {
                player.handGesture = HandGesture.Pending;
            }
        }

        
    }
}
