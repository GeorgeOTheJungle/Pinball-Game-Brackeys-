using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    // Controls game flippers.
    [Header("Flippers")]
    [SerializeField] private float m_speed = 0.0f;
    [SerializeField] private HingeJoint2D m_leftHingeJoint;
    [SerializeField] private HingeJoint2D m_rightHingeJoint;
    private JointMotor2D m_leftJointMotor2d;
    private JointMotor2D m_rightJointMotor2d;

    private bool m_leftIsFlipping = false;
    private bool m_rightIsFlipping = false;
    private InputController m_inputController;
    private void Awake()
    {
        m_inputController = GameObject.FindGameObjectWithTag("Player").GetComponent<InputController>();
    }

    private void OnEnable()
    {
        m_inputController.LeftFlipPressed += LeftFlip;
        m_inputController.RightFlipPressed += RightFlip;
    }

    private void OnDisable()
    {
        m_inputController.LeftFlipPressed -= LeftFlip;
        m_inputController.RightFlipPressed -= RightFlip;
    }


    private void Start()
    {
        m_leftJointMotor2d = m_leftHingeJoint.motor;
        m_rightJointMotor2d = m_rightHingeJoint.motor;
    }

    private void FixedUpdate()
    {
        if (m_leftIsFlipping)
        {
            m_leftJointMotor2d.motorSpeed = m_speed;
            m_leftHingeJoint.motor = m_leftJointMotor2d;
        } else
        {
            m_leftJointMotor2d.motorSpeed = -m_speed;
            m_leftHingeJoint.motor = m_leftJointMotor2d;
        }

        if (m_rightIsFlipping)
        {
            m_rightJointMotor2d.motorSpeed = -m_speed;
            m_rightHingeJoint.motor = m_rightJointMotor2d;
        }
        else
        {
            m_rightJointMotor2d.motorSpeed = m_speed;
            m_rightHingeJoint.motor = m_rightJointMotor2d;
        }
    }

    public void LeftFlip(bool value)
    {
        m_leftIsFlipping = value;
    }

    public void RightFlip(bool value)
    {
        m_rightIsFlipping = value;
    }
}
