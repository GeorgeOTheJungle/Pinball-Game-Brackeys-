using UnityEngine;

public class Ball : MonoBehaviour
{
    public int damage = 0;

    [SerializeField] private Transform m_spawnPoint;
    [SerializeField] private Rigidbody2D m_rigidBody2d;

    private void Start()
    {
        UpdateDamages();
    }

    public void OnBallLost()
    {
        // Lose a life here.

        transform.position = m_spawnPoint.position;
        m_rigidBody2d.velocity = Vector2.zero;

    }

    //Funcion para actualizar los damages
    public void UpdateDamages()
    {
        damage = PowerUps_Manager.Instance.ballDamage;
    }
}
