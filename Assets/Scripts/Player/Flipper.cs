using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Flipper : MonoBehaviour
{
    [Header("Flipper Settings: ")]
    [SerializeField] private int m_flipperMotorVelocity;
    [SerializeField] private int m_flipperMotorForce;
    private bool m_isRight = false;
    private bool m_flipping = false;

    private HingeJoint2D m_joint;
    private InputController m_inputController;

    private void Awake()
    {
        m_inputController = GameObject.FindGameObjectWithTag("Player").GetComponent<InputController>(); // 0 Idea why using an instance doesn't work lol
        m_joint = GetComponentInChildren<HingeJoint2D>();
    }

    private void OnEnable()
    {
        if(m_inputController != null)
        {
            m_inputController.LeftFlipPressed += Flip;
        }
    }

    private void OnDisable()
    {
        if (m_inputController != null)
        {
            m_inputController.LeftFlipPressed -= Flip;
        }
    }

    private void Update()
    {
        if (m_flipping)
        {
            m_joint.motor = RotateFlipper(m_flipperMotorVelocity, m_flipperMotorForce);
        }
        else
        {
            m_joint.motor = RotateFlipper(-m_flipperMotorVelocity, m_flipperMotorForce);
        }
    }

    private void Flip(bool value)
    {
        m_flipping = value;

    }


    private JointMotor2D RotateFlipper(float velocity, float force)
    {
        JointMotor2D joinMotor = new JointMotor2D();
        joinMotor.motorSpeed = force;
        joinMotor.maxMotorTorque = velocity;
        return joinMotor;
    }
}
