using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Flipper : MonoBehaviour
{
    [SerializeField] private bool m_isRight = false;
    [SerializeField] private float m_additionalTorqueForce = 150f;
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
            if (m_isRight) m_inputController.RightFlipPressed += Flip;
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
        float force = m_isRight ? -GameConfiguration.Instance.FlipperForce : GameConfiguration.Instance.FlipperForce;
        m_joint.AddTorque(force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if(TryGetComponent(out Rigidbody2D body))
            {
                body.AddForce(transform.up * m_additionalTorqueForce);
            }
        }
    }
}
