using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLock : MonoBehaviour
{
    //Variables privadas
    [SerializeField] private int availableShots = 3;
    [SerializeField] private float lifeTime = 25f;

    [Header("Bumper Variables")]
    [SerializeField] private float m_upwardsModifier = 1f;
    [SerializeField] private float m_bumperForce = 1000f;

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0 || availableShots <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Comprobar si la colision es de una bola o una fantasma
        if (other.collider.CompareTag("Ball") || other.collider.CompareTag("GhostBall"))
        {
            //Comprobar y obtener el rigidbody de la pelota
            if (other.collider.TryGetComponent(out Rigidbody2D ballRB))
            {
                var bumpDir = ballRB.position - (Vector2)transform.position;
                var bumpDistance = bumpDir.magnitude;

                if (m_upwardsModifier == 0)
                {
                    bumpDir /= bumpDistance;
                }   
                else
                {
                    // From Rigidbody.AddExplosionForce doc:
                    // If you pass a non-zero value for the upwardsModifier parameter, the direction
                    // will be modified by subtracting that value from the Y component of the centre point.
                    bumpDir.y += m_upwardsModifier;
                    bumpDir.Normalize();

                    ballRB.AddForce(Mathf.Lerp(0, m_bumperForce, (1 - bumpDistance)) * bumpDir, ForceMode2D.Force);
                    //ballRb.AddForce(collision.contacts[0].normal * m_bumperForce);
                }

                availableShots--;
            }
        }
    }
}
