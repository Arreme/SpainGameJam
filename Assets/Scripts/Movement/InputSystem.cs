// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Movement/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""3533d750-a009-4d30-869a-cf905b95327f"",
            ""actions"": [
                {
                    ""name"": ""LeftRight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""31e2cb8c-189e-4667-a569-a7056902744e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4b4520f7-c696-41bf-b2f4-ce2cade538e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d03bbe4f-8288-4029-92ad-169958402971"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpDown"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f4be91a7-c8de-4de5-b9f4-8912df20336b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6cc72346-c6a5-4222-993a-133b50a92ea7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d5ec8297-0a69-4974-b232-5141b2b0bbf8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6192d117-1ba1-40ea-89b2-174e14e73efa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bcb3c378-5a29-41a1-9c4b-016b0c018220"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c4755f18-9738-4ead-9d1c-d18cb8ba1818"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23417f0b-395e-42f5-b66c-80fed523c158"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""dd921001-36db-4d51-8793-b49ca57f26a2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""257fe27e-21da-45ee-9176-a41375ebaae0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a1e1778f-7aa6-4107-a66d-e737e66f64e4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bbaaa2f6-4747-4056-8475-ea2ca66f48e2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_LeftRight = m_Player1.FindAction("LeftRight", throwIfNotFound: true);
        m_Player1_Jump = m_Player1.FindAction("Jump", throwIfNotFound: true);
        m_Player1_Attack = m_Player1.FindAction("Attack", throwIfNotFound: true);
        m_Player1_UpDown = m_Player1.FindAction("UpDown", throwIfNotFound: true);
        m_Player1_Interact = m_Player1.FindAction("Interact", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_LeftRight;
    private readonly InputAction m_Player1_Jump;
    private readonly InputAction m_Player1_Attack;
    private readonly InputAction m_Player1_UpDown;
    private readonly InputAction m_Player1_Interact;
    public struct Player1Actions
    {
        private @InputSystem m_Wrapper;
        public Player1Actions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftRight => m_Wrapper.m_Player1_LeftRight;
        public InputAction @Jump => m_Wrapper.m_Player1_Jump;
        public InputAction @Attack => m_Wrapper.m_Player1_Attack;
        public InputAction @UpDown => m_Wrapper.m_Player1_UpDown;
        public InputAction @Interact => m_Wrapper.m_Player1_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @LeftRight.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLeftRight;
                @LeftRight.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLeftRight;
                @LeftRight.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLeftRight;
                @Jump.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttack;
                @UpDown.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUpDown;
                @UpDown.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUpDown;
                @UpDown.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUpDown;
                @Interact.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftRight.started += instance.OnLeftRight;
                @LeftRight.performed += instance.OnLeftRight;
                @LeftRight.canceled += instance.OnLeftRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @UpDown.started += instance.OnUpDown;
                @UpDown.performed += instance.OnUpDown;
                @UpDown.canceled += instance.OnUpDown;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);
    public interface IPlayer1Actions
    {
        void OnLeftRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnUpDown(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
