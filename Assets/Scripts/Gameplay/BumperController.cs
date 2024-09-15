using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class BumperController : MonoBehaviour
{
    [SerializeField] private int pointsToGive = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            ScoreManager.Instance.PointsToAdd(pointsToGive);
        }
    }
}
