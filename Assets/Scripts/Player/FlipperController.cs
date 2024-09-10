using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    // Controls game flippers.
    [Header("Hit force")]
    [SerializeField] private float m_hitForce = 150f;

    [Header("Colliders"), Space(10)]
    [SerializeField] private Collider2D[] m_flipperColliders;
    [SerializeField] private Collider2D[] m_idleColliders;
    public void Flip()
    {
        // TODO: en vez de rotarlo, usar la animacion, y que cheque con colliders si esta la bola.
        //StartCoroutine(FlipAnimation());
        //IEnumerator FlipAnimation()
        //{
        //    SetFlippers(true);

        //    yield return new WaitForSeconds(0.1f);

        //    SetFlippers(false);
        //}

        //void SetFlippers(bool value)
        //{
        //    foreach (var flipper in m_flipperColliders)
        //    {
        //        flipper.enabled = value;
        //    }

        //    foreach (var backFlipper in m_idleColliders)
        //    {
        //        backFlipper.enabled = !value;
        //    }
        //}
    }
}
