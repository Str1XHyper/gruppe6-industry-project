// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""2fd3be92-84e8-4dd7-82f8-049d8a7b11f5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""d6b44d69-9a15-49e8-aaa0-fd99f45f320c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Push to Talk"",
                    ""type"": ""Button"",
                    ""id"": ""668c56f1-0659-4f60-aeb1-55ceff18b35b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9374756b-2aad-40aa-a120-e33c22f0ac23"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce935bf4-9e80-4f9c-a54b-9936495b0423"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84cce0ef-302c-4fc4-a4a8-aa7789dbac0f"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Push to Talk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Blocks"",
            ""id"": ""32cd2f9e-6add-429e-8675-880633ace6cc"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4b1aed30-551f-4ad7-916d-e744a8dfe550"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9a539c2e-2fd9-42f0-8ac2-37f1c1236759"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""8daf8324-4cc2-4749-9d53-158ac2b7cffc"",
            ""actions"": [
                {
                    ""name"": ""Close Game"",
                    ""type"": ""Button"",
                    ""id"": ""97b0f656-de9d-479b-b861-6ad338f79372"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4376d2c8-9843-4690-a291-7f3d586f3667"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_PushtoTalk = m_Player.FindAction("Push to Talk", throwIfNotFound: true);
        // Blocks
        m_Blocks = asset.FindActionMap("Blocks", throwIfNotFound: true);
        m_Blocks_Interact = m_Blocks.FindAction("Interact", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_CloseGame = m_UI.FindAction("Close Game", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_PushtoTalk;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @PushtoTalk => m_Wrapper.m_Player_PushtoTalk;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @PushtoTalk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPushtoTalk;
                @PushtoTalk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPushtoTalk;
                @PushtoTalk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPushtoTalk;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @PushtoTalk.started += instance.OnPushtoTalk;
                @PushtoTalk.performed += instance.OnPushtoTalk;
                @PushtoTalk.canceled += instance.OnPushtoTalk;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Blocks
    private readonly InputActionMap m_Blocks;
    private IBlocksActions m_BlocksActionsCallbackInterface;
    private readonly InputAction m_Blocks_Interact;
    public struct BlocksActions
    {
        private @PlayerControls m_Wrapper;
        public BlocksActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Blocks_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Blocks; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BlocksActions set) { return set.Get(); }
        public void SetCallbacks(IBlocksActions instance)
        {
            if (m_Wrapper.m_BlocksActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_BlocksActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_BlocksActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_BlocksActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_BlocksActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public BlocksActions @Blocks => new BlocksActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_CloseGame;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CloseGame => m_Wrapper.m_UI_CloseGame;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @CloseGame.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCloseGame;
                @CloseGame.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCloseGame;
                @CloseGame.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCloseGame;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CloseGame.started += instance.OnCloseGame;
                @CloseGame.performed += instance.OnCloseGame;
                @CloseGame.canceled += instance.OnCloseGame;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPushtoTalk(InputAction.CallbackContext context);
    }
    public interface IBlocksActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnCloseGame(InputAction.CallbackContext context);
    }
}
