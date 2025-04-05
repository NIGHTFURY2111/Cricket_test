//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Input System/Player Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Hit Point"",
            ""id"": ""88dbf310-f8c0-445b-a1cb-8a8b0be1d14a"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""514db570-27c2-4fab-909b-bac08e302396"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Bowl"",
                    ""type"": ""Button"",
                    ""id"": ""d1f7e13c-f6a1-44da-828f-f668326b9467"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""reset"",
                    ""type"": ""Button"",
                    ""id"": ""3b91f35c-497a-47de-902e-335cc707f727"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""1d5d8781-cb36-40bb-b2b7-81198f4f6da7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""31edaf21-00d3-42a7-bd26-6f1bccf4281c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5d15cad2-02c2-4b07-888f-fd0ed5303b93"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c66e82f6-c3b6-4aff-a7b9-58d75d6a93f7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d73c6cf3-c5a9-4dc2-aae0-f4fe67cc96ea"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""f8fa4bbc-c005-40c1-aed5-4262c2242ca3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""57bae802-caf5-495d-8352-2eed3d790a0d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fe20bb02-bede-4ca1-a594-7a056462d68b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""816832fb-0f22-4b63-8d46-442758876f46"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""85a5ae68-59a4-4b50-b7fc-739ee172610b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3b2cda88-c84e-4a47-8098-721f464c2722"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bowl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e386a9c-7944-476b-8178-1630362bcfac"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hit Point
        m_HitPoint = asset.FindActionMap("Hit Point", throwIfNotFound: true);
        m_HitPoint_move = m_HitPoint.FindAction("move", throwIfNotFound: true);
        m_HitPoint_Bowl = m_HitPoint.FindAction("Bowl", throwIfNotFound: true);
        m_HitPoint_reset = m_HitPoint.FindAction("reset", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Hit Point
    private readonly InputActionMap m_HitPoint;
    private List<IHitPointActions> m_HitPointActionsCallbackInterfaces = new List<IHitPointActions>();
    private readonly InputAction m_HitPoint_move;
    private readonly InputAction m_HitPoint_Bowl;
    private readonly InputAction m_HitPoint_reset;
    public struct HitPointActions
    {
        private @PlayerControls m_Wrapper;
        public HitPointActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_HitPoint_move;
        public InputAction @Bowl => m_Wrapper.m_HitPoint_Bowl;
        public InputAction @reset => m_Wrapper.m_HitPoint_reset;
        public InputActionMap Get() { return m_Wrapper.m_HitPoint; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HitPointActions set) { return set.Get(); }
        public void AddCallbacks(IHitPointActions instance)
        {
            if (instance == null || m_Wrapper.m_HitPointActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HitPointActionsCallbackInterfaces.Add(instance);
            @move.started += instance.OnMove;
            @move.performed += instance.OnMove;
            @move.canceled += instance.OnMove;
            @Bowl.started += instance.OnBowl;
            @Bowl.performed += instance.OnBowl;
            @Bowl.canceled += instance.OnBowl;
            @reset.started += instance.OnReset;
            @reset.performed += instance.OnReset;
            @reset.canceled += instance.OnReset;
        }

        private void UnregisterCallbacks(IHitPointActions instance)
        {
            @move.started -= instance.OnMove;
            @move.performed -= instance.OnMove;
            @move.canceled -= instance.OnMove;
            @Bowl.started -= instance.OnBowl;
            @Bowl.performed -= instance.OnBowl;
            @Bowl.canceled -= instance.OnBowl;
            @reset.started -= instance.OnReset;
            @reset.performed -= instance.OnReset;
            @reset.canceled -= instance.OnReset;
        }

        public void RemoveCallbacks(IHitPointActions instance)
        {
            if (m_Wrapper.m_HitPointActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHitPointActions instance)
        {
            foreach (var item in m_Wrapper.m_HitPointActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_HitPointActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HitPointActions @HitPoint => new HitPointActions(this);
    public interface IHitPointActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnBowl(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
    }
}
