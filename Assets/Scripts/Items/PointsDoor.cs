using UnityEngine;

public class PointsDoor : MonoBehaviour
{
    //Variables privadas
    [SerializeField] private int pointsToGive = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "GhostBall")
        {
            ScoreManager.Instance.PointsToAdd(pointsToGive);
        }
    }
}
