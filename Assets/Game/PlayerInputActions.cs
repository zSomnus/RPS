// GENERATED AUTOMATICALLY FROM 'Assets/Game/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player Controls"",
            ""id"": ""6008df87-4dfc-4ebf-a918-37e7cb2ecb6d"",
            ""actions"": [
                {
                    ""name"": ""P1Rock"",
                    ""type"": ""Button"",
                    ""id"": ""75a6e659-5181-4d39-a3fb-fe9907a80d78"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P1Paper"",
                    ""type"": ""Button"",
                    ""id"": ""21fb5b31-d07f-4af2-99af-8a898aeef15e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""P1Scissors"",
                    ""type"": ""Button"",
                    ""id"": ""1a66ce8a-adc9-4d17-8d3e-c0730d237910"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P2Rock"",
                    ""type"": ""Button"",
                    ""id"": ""4d4c2103-7dfa-4177-a9da-cf173b2cfeab"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P2Paper"",
                    ""type"": ""Button"",
                    ""id"": ""0cc15529-9f4e-4183-9bf0-f3bcd8abf53b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P2Scissor"",
                    ""type"": ""Button"",
                    ""id"": ""47eeb977-f3be-4029-a869-fbf0ef613b58"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""86d89fdf-2701-42ac-8c3f-2fb0163c154a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Rock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""534ef321-5139-4fc4-9870-73389ba09d14"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Paper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bb9df04-aae6-4ce2-8fda-30f131abfde1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Scissors"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2eeb1434-b2cd-4976-9d62-b7fbf7b00217"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2Rock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d00f387c-b567-47f8-9bbf-58bd6bc71ef4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2Paper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03973e49-4a18-41c6-93ad-1c19d59d271f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2Scissor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Test"",
            ""id"": ""c1a5d178-5a96-4a9f-b3ac-afbc82a811bc"",
            ""actions"": [
                {
                    ""name"": ""BackToMainGame"",
                    ""type"": ""Button"",
                    ""id"": ""d2735ce6-b3f1-4c03-a1b3-8bf18d3c1743"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5ebe0d9f-d75d-41f1-b824-3dec334214bd"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackToMainGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MiniGameControls"",
            ""id"": ""ece53010-fde0-4144-9a8d-33c0b87e3c77"",
            ""actions"": [
                {
                    ""name"": ""Chicken"",
                    ""type"": ""Button"",
                    ""id"": ""b614d3b4-e792-4c78-bc88-b810c3a9d903"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Viper"",
                    ""type"": ""Button"",
                    ""id"": ""17f315f5-a653-4253-93df-59f0ad7906f5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8a55b6f8-bb56-4e51-9084-6d0fb4ecc6a5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Chicken"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71fd3506-1e2d-4021-9971-057a6fa9ed2d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Viper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Controls
        m_PlayerControls = asset.FindActionMap("Player Controls", throwIfNotFound: true);
        m_PlayerControls_P1Rock = m_PlayerControls.FindAction("P1Rock", throwIfNotFound: true);
        m_PlayerControls_P1Paper = m_PlayerControls.FindAction("P1Paper", throwIfNotFound: true);
        m_PlayerControls_P1Scissors = m_PlayerControls.FindAction("P1Scissors", throwIfNotFound: true);
        m_PlayerControls_P2Rock = m_PlayerControls.FindAction("P2Rock", throwIfNotFound: true);
        m_PlayerControls_P2Paper = m_PlayerControls.FindAction("P2Paper", throwIfNotFound: true);
        m_PlayerControls_P2Scissor = m_PlayerControls.FindAction("P2Scissor", throwIfNotFound: true);
        // Test
        m_Test = asset.FindActionMap("Test", throwIfNotFound: true);
        m_Test_BackToMainGame = m_Test.FindAction("BackToMainGame", throwIfNotFound: true);
        // MiniGameControls
        m_MiniGameControls = asset.FindActionMap("MiniGameControls", throwIfNotFound: true);
        m_MiniGameControls_Chicken = m_MiniGameControls.FindAction("Chicken", throwIfNotFound: true);
        m_MiniGameControls_Viper = m_MiniGameControls.FindAction("Viper", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player Controls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_P1Rock;
    private readonly InputAction m_PlayerControls_P1Paper;
    private readonly InputAction m_PlayerControls_P1Scissors;
    private readonly InputAction m_PlayerControls_P2Rock;
    private readonly InputAction m_PlayerControls_P2Paper;
    private readonly InputAction m_PlayerControls_P2Scissor;
    public struct PlayerControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @P1Rock => m_Wrapper.m_PlayerControls_P1Rock;
        public InputAction @P1Paper => m_Wrapper.m_PlayerControls_P1Paper;
        public InputAction @P1Scissors => m_Wrapper.m_PlayerControls_P1Scissors;
        public InputAction @P2Rock => m_Wrapper.m_PlayerControls_P2Rock;
        public InputAction @P2Paper => m_Wrapper.m_PlayerControls_P2Paper;
        public InputAction @P2Scissor => m_Wrapper.m_PlayerControls_P2Scissor;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @P1Rock.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP1Rock;
                @P1Rock.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP1Rock;
                @P1Rock.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP1Rock;
                @P1Paper.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP1Paper;
                @P1Paper.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP1Paper;
                @P1Paper.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP1Paper;
                @P1Scissors.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP1Scissors;
                @P1Scissors.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP1Scissors;
                @P1Scissors.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP1Scissors;
                @P2Rock.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP2Rock;
                @P2Rock.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP2Rock;
                @P2Rock.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP2Rock;
                @P2Paper.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP2Paper;
                @P2Paper.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP2Paper;
                @P2Paper.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP2Paper;
                @P2Scissor.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP2Scissor;
                @P2Scissor.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP2Scissor;
                @P2Scissor.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnP2Scissor;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @P1Rock.started += instance.OnP1Rock;
                @P1Rock.performed += instance.OnP1Rock;
                @P1Rock.canceled += instance.OnP1Rock;
                @P1Paper.started += instance.OnP1Paper;
                @P1Paper.performed += instance.OnP1Paper;
                @P1Paper.canceled += instance.OnP1Paper;
                @P1Scissors.started += instance.OnP1Scissors;
                @P1Scissors.performed += instance.OnP1Scissors;
                @P1Scissors.canceled += instance.OnP1Scissors;
                @P2Rock.started += instance.OnP2Rock;
                @P2Rock.performed += instance.OnP2Rock;
                @P2Rock.canceled += instance.OnP2Rock;
                @P2Paper.started += instance.OnP2Paper;
                @P2Paper.performed += instance.OnP2Paper;
                @P2Paper.canceled += instance.OnP2Paper;
                @P2Scissor.started += instance.OnP2Scissor;
                @P2Scissor.performed += instance.OnP2Scissor;
                @P2Scissor.canceled += instance.OnP2Scissor;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // Test
    private readonly InputActionMap m_Test;
    private ITestActions m_TestActionsCallbackInterface;
    private readonly InputAction m_Test_BackToMainGame;
    public struct TestActions
    {
        private @PlayerInputActions m_Wrapper;
        public TestActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @BackToMainGame => m_Wrapper.m_Test_BackToMainGame;
        public InputActionMap Get() { return m_Wrapper.m_Test; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestActions set) { return set.Get(); }
        public void SetCallbacks(ITestActions instance)
        {
            if (m_Wrapper.m_TestActionsCallbackInterface != null)
            {
                @BackToMainGame.started -= m_Wrapper.m_TestActionsCallbackInterface.OnBackToMainGame;
                @BackToMainGame.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnBackToMainGame;
                @BackToMainGame.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnBackToMainGame;
            }
            m_Wrapper.m_TestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @BackToMainGame.started += instance.OnBackToMainGame;
                @BackToMainGame.performed += instance.OnBackToMainGame;
                @BackToMainGame.canceled += instance.OnBackToMainGame;
            }
        }
    }
    public TestActions @Test => new TestActions(this);

    // MiniGameControls
    private readonly InputActionMap m_MiniGameControls;
    private IMiniGameControlsActions m_MiniGameControlsActionsCallbackInterface;
    private readonly InputAction m_MiniGameControls_Chicken;
    private readonly InputAction m_MiniGameControls_Viper;
    public struct MiniGameControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public MiniGameControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Chicken => m_Wrapper.m_MiniGameControls_Chicken;
        public InputAction @Viper => m_Wrapper.m_MiniGameControls_Viper;
        public InputActionMap Get() { return m_Wrapper.m_MiniGameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MiniGameControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMiniGameControlsActions instance)
        {
            if (m_Wrapper.m_MiniGameControlsActionsCallbackInterface != null)
            {
                @Chicken.started -= m_Wrapper.m_MiniGameControlsActionsCallbackInterface.OnChicken;
                @Chicken.performed -= m_Wrapper.m_MiniGameControlsActionsCallbackInterface.OnChicken;
                @Chicken.canceled -= m_Wrapper.m_MiniGameControlsActionsCallbackInterface.OnChicken;
                @Viper.started -= m_Wrapper.m_MiniGameControlsActionsCallbackInterface.OnViper;
                @Viper.performed -= m_Wrapper.m_MiniGameControlsActionsCallbackInterface.OnViper;
                @Viper.canceled -= m_Wrapper.m_MiniGameControlsActionsCallbackInterface.OnViper;
            }
            m_Wrapper.m_MiniGameControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Chicken.started += instance.OnChicken;
                @Chicken.performed += instance.OnChicken;
                @Chicken.canceled += instance.OnChicken;
                @Viper.started += instance.OnViper;
                @Viper.performed += instance.OnViper;
                @Viper.canceled += instance.OnViper;
            }
        }
    }
    public MiniGameControlsActions @MiniGameControls => new MiniGameControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnP1Rock(InputAction.CallbackContext context);
        void OnP1Paper(InputAction.CallbackContext context);
        void OnP1Scissors(InputAction.CallbackContext context);
        void OnP2Rock(InputAction.CallbackContext context);
        void OnP2Paper(InputAction.CallbackContext context);
        void OnP2Scissor(InputAction.CallbackContext context);
    }
    public interface ITestActions
    {
        void OnBackToMainGame(InputAction.CallbackContext context);
    }
    public interface IMiniGameControlsActions
    {
        void OnChicken(InputAction.CallbackContext context);
        void OnViper(InputAction.CallbackContext context);
    }
}
