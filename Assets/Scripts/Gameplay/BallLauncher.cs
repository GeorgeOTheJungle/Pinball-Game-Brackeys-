using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private InputController m_inputController;

    [SerializeField] private float m_holdTimeGrowth = 15f;
    [SerializeField] private float m_currentHoldTime;

    [SerializeField] private Rigidbody2D m_ballRigidBody;
    [SerializeField] private SpriteRenderer m_launcherSpriteRenderer;
    [SerializeField] private Transform m_launcherCollider;
    private bool m_holding = false;

    [SerializeField] private BallLauncherState[] m_launchStates;
    [Space(10)]
    private bool m_isLaunching = false;
    [SerializeField] private Sprite[] m_launchAnimation;

    private bool wasPressed = false;
    private void Awake()
    {
        m_inputController = GameObject.FindGameObjectWithTag("Player").GetComponent<InputController>();

        m_launcherSpriteRenderer.sprite = m_launchStates[0].m_ballLauncherSprite;
        m_launcherCollider.localPosition = m_launchStates[0].m_colliderPosition;
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

    int index = 0;
    private void Update()
    {
        if (m_holding)
        {
            m_currentHoldTime += m_holdTimeGrowth * Time.deltaTime;
            if (m_currentHoldTime > m_launchStates[m_launchStates.Length - 1].m_endingHoldTime)
                m_currentHoldTime = m_launchStates[m_launchStates.Length - 1].m_endingHoldTime;

            if (m_currentHoldTime > m_launchStates[index].m_endingHoldTime && index < m_launchStates.Length - 1)
            {
                m_launcherCollider.localPosition = m_launchStates[index].m_colliderPosition;
                m_launcherSpriteRenderer.sprite = m_launchStates[index].m_ballLauncherSprite;
                index++;
            }
        }
    }

    private void OnLaunchPress(bool pressed)
    {
        m_holding = pressed;
        if (pressed) return;

        if (Ball.Instance.BallState != BallGameState.idle) return;
        // TODO check game state if ball in launcher, then shoot.


        //Ball.Instance.BallState = BallGameState.playing;
        m_ballRigidBody.AddForce(transform.up * m_launchStates[index].m_launchForce);
        // Play launch animation
        StartCoroutine(PlayLaunchAnimation());
        index = 0;
        m_currentHoldTime = 0.0f;
    }

    private IEnumerator PlayLaunchAnimation()
    {
        float frameRate = 0.1f;

        foreach (Sprite sprite in m_launchAnimation)
        {
            m_launcherSpriteRenderer.sprite = sprite;
            yield return new WaitForSeconds(frameRate);
        }
        m_launcherSpriteRenderer.sprite = m_launchStates[0].m_ballLauncherSprite;
        yield return new WaitForSeconds(0.5f);
        m_launcherCollider.localPosition = m_launchStates[0].m_colliderPosition;
    }

    [Serializable]
    private struct BallLauncherState
    {
        public float m_startingHoldTime;
        public float m_endingHoldTime;
        public float m_launchForce;
        [Space]
        public Vector2 m_colliderPosition;
        public Sprite m_ballLauncherSprite;
    }
}
