using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController Instance;

    public delegate void SingleEvent();
    public delegate void BoolEvent(bool value);

    public SingleEvent LeftFlipPressed;
    public SingleEvent RightFlipPressed;
    public BoolEvent LauncherEvent;

    private UserInput m_playerInput;

    private void Awake()
    {
        Instance = this;

        m_playerInput = new UserInput();
        m_playerInput.Enable();

        m_playerInput.Gameplay.LeftFlip.performed += _ => LeftFlipPressed?.Invoke();
        m_playerInput.Gameplay.RightFlip.performed += _ => RightFlipPressed?.Invoke();

        m_playerInput.Gameplay.LauncherHold.performed += _ => LauncherEvent?.Invoke(true);
        m_playerInput.Gameplay.LauncherHold.canceled += _ => LauncherEvent?.Invoke(false);
    }
}
