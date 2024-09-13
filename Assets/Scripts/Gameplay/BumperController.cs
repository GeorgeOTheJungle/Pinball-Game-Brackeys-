using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class BumperController : MonoBehaviour
{
    [SerializeField] private int pointsToGive = 100;
    [SerializeField] private float m_upwardsModifier = 1f;
    [SerializeField] private float m_bumperForce = 150f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            if (collision.collider.TryGetComponent(out Rigidbody2D ballRb))
            {
                var bumpDir = ballRb.position - (Vector2)transform.position;
                var bumpDistance = bumpDir.magnitude;

                if (m_upwardsModifier == 0)
                    bumpDir /= bumpDistance;
                else
                {
                    // From Rigidbody.AddExplosionForce doc:
                    // If you pass a non-zero value for the upwardsModifier parameter, the direction
                    // will be modified by subtracting that value from the Y component of the centre point.
                    bumpDir.y += m_upwardsModifier;
                    bumpDir.Normalize();

                    // ballRb.AddForce(Mathf.Lerp(0, m_bumperForce, (1 - bumpDistance)) * bumpDir, ForceMode2D.Force);
                    //ballRb.AddForce(collision.contacts[0].normal * m_bumperForce);
                    ballRb.AddForce(collision.contacts[0].normal * m_bumperForce, ForceMode2D.Impulse);
                }

                ScoreManager.Instance.PointsToAdd(pointsToGive);
            }
        }
    }
}
