using UnityEngine;

public class BottomGap : MonoBehaviour
{
    [SerializeField] private Ball m_ball;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            ScoreManager.Instance.TakeLife();
            m_ball.OnBallLost();
        }

        if (collision.CompareTag("BadBall"))
        {
            GameManager.Instance.BlockPlayer();
        }
    }
}
