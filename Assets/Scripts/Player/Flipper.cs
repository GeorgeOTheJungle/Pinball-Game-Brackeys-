using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private bool isRight = false;
    [SerializeField] private float m_torqueForce = 150f;
    [SerializeField] private Rigidbody2D m_joint;

    private InputController m_inputController;

    private void Awake()
    {
        m_inputController = GameObject.FindGameObjectWithTag("Player").GetComponent<InputController>(); // 0 Idea why using an instance doesn't work lol
    }

    private void OnEnable()
    {
        if (m_inputController)
        {
            if (isRight) m_inputController.RightFlipPressed += Flip;
            else m_inputController.LeftFlipPressed += Flip;
        }
    }

    private void OnDisable()
    {
        if (m_inputController)
        {
            m_inputController.RightFlipPressed -= Flip;
            m_inputController.LeftFlipPressed -= Flip;
        }
    }

    public void Flip()
    {
        Debug.Log("Performing Flip");
        m_joint.AddTorque(m_torqueForce);
    }
}
