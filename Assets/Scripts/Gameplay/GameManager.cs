using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    //Variables publicas
    public bool isPlaying = false;
    public bool bossPhase = false;
    public bool win = false;
    public bool blocked = false;

    //Variables privadas
    [Header("PlayerBalls Configuration")]
    public GameObject playerBall;
    [SerializeField] private Rigidbody2D m_rigidBody2d;
    [SerializeField] private Transform ballSpawn;

    [Header("First Phase Configuration")]
    [SerializeField] private bool firstPhase = true;
    [SerializeField] private float firstPhaseTime = 60f;

    [Header("Boss Settings")]
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject turnOffStage;
    [SerializeField] private float blockedTime = 2f;
    private float _blockedTime;

    private void Update()
    {
        if (isPlaying && firstPhase)
        {
            firstPhaseTime -= Time.deltaTime;

            //Fin de la primera fase, y abrir la tienda
            if (firstPhaseTime <= 0)
            {
                firstPhase = false;
                isPlaying = false;

                UI_Manager.Instance.OpenShop();
            }
        }

        if (blocked)
        {
            _blockedTime -= Time.deltaTime;

            if (_blockedTime <= 0)
            {
                UnlockPlayer();
            }
        }
    }

    #region Game States
    //Funcion para iniciar el juego
    public void StartGame()
    {
        isPlaying = true;
        playerBall.SetActive(true);
        SpawnABall();
    }

    //Funcion para terminar el juego
    public void GameOver()
    {
        UI_Manager.Instance.ShowGameOver();
        isPlaying = false;
    }

    //Funcion de victoria
    public void Win()
    {

    }
    #endregion

    #region Boss Functions
    //Funcion para iniciar la fase del boss
    public void StartBossPhase()
    {
        turnOffStage.SetActive(false);
        boss.SetActive(true);
        bossPhase = true;

        UI_Manager.Instance.CloseShop();
        isPlaying = true;
    }

    //Funcion para bloquear al jugador
    public void BlockPlayer()
    {
        blocked = true;
        _blockedTime = blockedTime;
        InputController.Instance.m_playerInput.Disable();
    }

    //Funcion para desbloquear al jugador
    public void UnlockPlayer()
    {
        blocked = false;
        InputController.Instance.m_playerInput.Enable();
    }
    #endregion

    //Funcion para invocar una bola
    public void SpawnABall()
    {
        if (ScoreManager.Instance.currentLife > 0)
        {
            playerBall.gameObject.transform.position = ballSpawn.position;
            m_rigidBody2d.velocity = Vector2.zero;
        }
    }
}
