using Game.Scripts;
using UnityEngine;

namespace ChickenSnakeGame.Scripts
{
    public class GameParameter: MonoBehaviour
    {
        [SerializeField]private int _scoreRequired = 3;
        public int attackerPlayerIndex;
        public int defenderPlayerIndex;
        public float defenseSuccessDamageModifier = 0.5f;
        /// <summary>
        /// The acount of health that deals to player if they lose
        /// </summary>
        public int healthDealtToPlayer;
        public static GameParameter instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            if (AirConsoleController.instance != null)
            {
                attackerPlayerIndex = AirConsoleController.instance.miniGameInputData.attackPlayer.index;
                defenderPlayerIndex = AirConsoleController.instance.miniGameInputData.defensePlayer.index;
            }
            else
            {
                attackerPlayerIndex = 1;
                defenderPlayerIndex = 2;
            }
        }

        public int scoreRequired
        {
            get => _scoreRequired;
            set => _scoreRequired = value;
        }
    }
}