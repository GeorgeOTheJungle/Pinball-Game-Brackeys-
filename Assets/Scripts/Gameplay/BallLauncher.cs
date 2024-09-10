using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private InputController m_inputController;
    [SerializeField] private float m_maxLaunchForce = 350f;
    [SerializeField] private float m_launchForceRate = 15f;
    [SerializeField] private float m_currentLaunchForce;

    [SerializeField] private Rigidbody2D m_ballRigidBody;
    private bool m_holding = false;
    private void Awake()
    {
        m_inputController = GameObject.FindGameObjectWithTag("Player").GetComponent<InputController>();
    }
    private void OnEnable()
    {
        if (m_inputController)
        {
            m_inputController.LauncherEvent += OnLaunchPress;
        }
    }

    private void OnDisable()
    {
        if (m_inputController)
        {
            m_inputController.LauncherEvent -= OnLaunchPress;
        }
    }

    private void Update()
    {
        if (m_holding)
        {
            m_currentLaunchForce += m_launchForceRate * Time.deltaTime;
            if (m_currentLaunchForce > m_maxLaunchForce) m_currentLaunchForce = m_maxLaunchForce;
        }
    }

    private void OnLaunchPress(bool pressed)
    {
        if (pressed) m_holding = pressed;
        else
        {
            m_ballRigidBody.AddForce(transform.up * m_currentLaunchForce);
            m_holding = false;
            m_currentLaunchForce = 0.0f;
        }
    }
}
