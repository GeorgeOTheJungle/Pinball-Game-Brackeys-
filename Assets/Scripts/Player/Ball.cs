using UnityEngine;

public class Ball : MonoBehaviour
{
    //Variables publicas
    public static Ball Instance { get; private set; }
    public BallGameState BallState
    {
        get
        {
            return m_ballState;
        }

        set
        {
            m_ballState = value;
            OnBallStateChange();
        }
    }

    public int damage = 0;
    [SerializeField] private BallGameState m_ballState;
    [SerializeField] private PhysicsMaterial2D m_bouncyBallState;
    private Rigidbody2D m_rigidBody;
    private Collider2D m_collider;


    private void Awake()
    {
        Instance = this;
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        BallState = BallGameState.idle;
        UpdateDamages();
    }

    public void OnBallLost()
    {
        GameManager.Instance.SpawnABall();
        BallState = BallGameState.idle;
    }

    public void OnBallStateChange()
    {
        switch (m_ballState)
        {
            case BallGameState.idle:
                m_collider.sharedMaterial = null;

                break;
            case BallGameState.playing:
                m_collider.sharedMaterial = m_bouncyBallState;
                break;
            case BallGameState.respawning:
                break;
        }
    }

    //Funcion para actualizar los damages
    public void UpdateDamages()
    {
        damage = PowerUps_Manager.Instance.ballDamage;
    }
}
public enum BallGameState
{
    idle,
    playing,
    respawning
}
