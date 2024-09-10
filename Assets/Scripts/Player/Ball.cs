using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int Damage = 0;

    [SerializeField] private Transform m_spawnPoint;
    [SerializeField] private Rigidbody2D m_rigidBody2d;

    public void OnBallLost()
    {
        // Lose a life here.

        transform.position = m_spawnPoint.position;
        m_rigidBody2d.velocity = Vector2.zero;

    }
}
