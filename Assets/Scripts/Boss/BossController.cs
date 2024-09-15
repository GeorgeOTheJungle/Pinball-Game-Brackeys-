using UnityEngine;

public class BossController : MonoBehaviour
{
    //Variables privadas
    [Header("Boss Stats")]
    [SerializeField] private int life = 100;
    [SerializeField] private float speed = 5f;

    [Header("Timers De Accion")]
    [SerializeField] private float actionTimer;
    [SerializeField] [Range(0f, 1f)] private float actionTimeFactor = 0.1f;

    [Header("Patrol Positions")]
    [SerializeField] private Transform[] positions;
    private Transform nextPos;
    private int nextPosIndex;
    private bool arrive = true;

    [Header("Walls Invocation")]
    [SerializeField] private GameObject wallPrefab1;
    [SerializeField] private GameObject wallPrefab2;
    [SerializeField] private Transform[] wallPositions;
    private int wallPosIndex;

    [Header("Bad Ball Invocation")]
    [SerializeField] private GameObject badBallPrefab;
    [SerializeField] private Transform badBallPosition;

    private float timeAlive;
    private float timeUntilDoAnAction;
    private float _actionTimer;

    private void Start()
    {
        nextPos = positions[0];
    }

    private void Update()
    {
        if (GameManager.Instance.bossPhase == true)
        {
            timeAlive += Time.deltaTime;
            CalculateFactors();
            DoAMove();
        }

        //Movimiento del boss
        if (!arrive)
        {
            BossMove();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ball" || other.collider.tag == "GhostBall")
        {
            life -= PowerUps_Manager.Instance.ballDamage;

            if (life <= 0)
            {
                GameManager.Instance.Win();
            }
        }
    }

    //Funcion para seleccionar un movimiento
    private void DoAMove()
    {
        timeUntilDoAnAction += Time.deltaTime;

        if (timeUntilDoAnAction >= _actionTimer)
        {
            SelectAMove();
            timeUntilDoAnAction = 0;
        }
    }

    //Funcion para seleccionar un movimiento
    private void SelectAMove()
    {
        int selectedMove = Random.Range(0, 5);

        switch (selectedMove)
        {
            case 0:
                //Descansar
                break;

            case 1:
                CanMove();
                break;

            case 2:
                SpawnWalls(false);
                break;

            case 3:
                SpawnWalls(true);
                break;

            case 4:
                SpawnBadBall();
                break;
        }
    }

    //Funcion para calcular los factores segun el tiempo de juego
    private void CalculateFactors()
    {
        _actionTimer = actionTimer / Mathf.Pow(timeAlive, actionTimeFactor);
    }


    //Funcion para indicar cuando se debe mover 
    private void CanMove()
    {
        arrive = false;
        
        nextPosIndex = Random.Range(0, positions.Length);

        nextPos = positions[nextPosIndex];
    }

    //Funcion para mover al jefe a una de las posiciones de forma aleatoria
    private void BossMove()
    {
        if (transform.position == nextPos.position)
        {
            arrive = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
        }
    }

    //Funcion para crear una pared
    private void SpawnWalls(bool multiple)
    {
        wallPosIndex = Random.Range(0, wallPositions.Length);

        if (multiple)
        {
            Instantiate(wallPrefab2, wallPositions[wallPosIndex].position, Quaternion.identity);
        }
        else
        {
            Instantiate(wallPrefab1, wallPositions[wallPosIndex].position, Quaternion.identity);
        }
    }

    //Funcion para spawnear la bola mala
    private void SpawnBadBall()
    {
        Instantiate(badBallPrefab, badBallPosition.position, Quaternion.identity);
    }
}
