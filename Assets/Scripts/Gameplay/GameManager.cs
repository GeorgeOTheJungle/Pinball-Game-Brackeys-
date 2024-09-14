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

    //Variables privadas
    [Header("PlayerBalls Configuration")]
    [SerializeField] private GameObject playerBall;
    [SerializeField] private Rigidbody2D m_rigidBody2d;
    [SerializeField] private Transform ballSpawn;

    [Header("First Phase Configuration")]
    [SerializeField] private bool firstPhase = true;
    [SerializeField] private float firstPhaseTime = 60f;

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
    }

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

    //Funcion para iniciar la fase del boss
    public void StartBossPhase()
    {
        //Invocar boss y desactivar parte del mapa

        UI_Manager.Instance.CloseShop();
        isPlaying = true;
    }

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
