using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController Instance;

    public delegate void SingleEvent();

    public SingleEvent LeftFlipPressed;
    public SingleEvent RightFlipPressed;

    private UserInput m_playerInput;

    private void Awake()
    {
        Instance = this;

        m_playerInput = new UserInput();
        m_playerInput.Enable();

        m_playerInput.Gameplay.LeftFlip.performed += _ => LeftFlipPressed?.Invoke();
        m_playerInput.Gameplay.RightFlip.performed += _ => RightFlipPressed?.Invoke();
    }
}
