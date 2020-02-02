using Game.Scripts.DataClass;
using UnityEngine;

namespace Game.Scripts
{
    public class KeyboardTester : MonoBehaviour
    {
        private PlayerInputActions inputAction;

        private bool player1Scissor;
        private bool player1Paper;
        private bool player1Rock;
        private bool player2Scissor;
        private bool player2Paper;
        private bool player2Rock;

        private void Awake()
        {
            inputAction = new PlayerInputActions();
            // inputAction.PlayerControls.P1Paper.performed += ctx => player1Paper = true;
            inputAction.PlayerControls.P1Paper.performed += ctx => player1Paper = true;
            inputAction.PlayerControls.P1Rock.performed += ctx => player1Rock = true;
            inputAction.PlayerControls.P1Scissors.performed += ctx => player1Scissor = true;
            inputAction.PlayerControls.P2Paper.performed += ctx => player2Paper = true;
            inputAction.PlayerControls.P2Rock.performed += ctx => player2Rock = true;
            inputAction.PlayerControls.P2Scissor.performed += ctx => player2Scissor = true;
        }

        private void Start()
        {

        }

        /// <summary>
        /// For testing purpose
        /// </summary>
        private void Update()
        {
            if (player1Paper)
            {
                print("Player 1 is pressing paper");
                AirConsoleController.players[0].handGesture = HandGesture.Chicken;
                player1Paper = false;
            
            
                GameManager.instance.TryGeneratePlayerCard();
                GameManager.instance.TryFlipCardIfPlayerReady();
            }

            if (player1Scissor)
            {
                print("Player 1 is pressing scissor");
                AirConsoleController.players[0].handGesture = HandGesture.Fox;
                player1Scissor = false;

            
                GameManager.instance.TryGeneratePlayerCard();
                GameManager.instance.TryFlipCardIfPlayerReady();
            }

            if (player1Rock)
            {
                print("Player 1 is pressing rock");
                AirConsoleController.players[0].handGesture = HandGesture.Viper;
                player1Rock = false;
            
                GameManager.instance.TryGeneratePlayerCard();
                GameManager.instance.TryFlipCardIfPlayerReady();

            }
        
            if (player2Paper)
            {
                print("Player 2 is pressing paper");
                AirConsoleController.players[1].handGesture = HandGesture.Chicken;
                player2Paper = false;
            
                GameManager.instance.TryGeneratePlayerCard();
                GameManager.instance.TryFlipCardIfPlayerReady();

            }

            if (player2Scissor)
            {
                print("Player 2 is pressing scissor");
                AirConsoleController.players[1].handGesture = HandGesture.Fox;
                player2Scissor = false;
            
                GameManager.instance.TryGeneratePlayerCard();
                GameManager.instance.TryFlipCardIfPlayerReady();

            }

            if (player2Rock)
            {
                print("Player 2 is pressing Rock");
                AirConsoleController.players[1].handGesture = HandGesture.Viper;
                player2Rock = false;
            
                GameManager.instance.TryGeneratePlayerCard();
                GameManager.instance.TryFlipCardIfPlayerReady();

            }

            if (AirConsoleController.instance.PlayersMadeMoves())
            {
                // GameManager.instance.TryGeneratePlayerCard();
                GameManager.instance.TryUpdateReadyUI();

            }

        
        
        

        }
 
        private void OnEnable()
        {
            inputAction.Enable();
        }

        private void OnDisable()
        {
            inputAction.Disable();
        }
    }
}
