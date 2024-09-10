using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomGap : MonoBehaviour
{
    [SerializeField] private Ball m_ball;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            m_ball.OnBallLost();
        }
    }
}
