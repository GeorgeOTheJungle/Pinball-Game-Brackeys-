using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    //Variables publicas
    public int currentLife;
    public int currentScore = 0;

    //Variables provadas
    [Header("Life System")]
    [SerializeField] private bool canTakeDamage;
    [SerializeField] private int maxLife;
    [SerializeField] private int initialLife;

    private void Start()
    {
        currentLife = initialLife;
    }

    #region Life System
    //Funcion para sumar una vida al jugador
    public void AddLife()
    {
        currentLife++;

        //If que limita el numero de vida maxima
        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
    }

    //Funcion para quitar una vida al jugador
    public void TakeLife()
    {
        if (canTakeDamage == false) return;
        currentLife--;

        //Activar menu de GameOver y evitar valores negativos
        if (currentLife <= 0)
        {
            GameManager.Instance.GameOver();
            currentLife = 0;
        }
    }
    #endregion

    #region Points System
    //Funcion para sumar puntos
    public void PointsToAdd(int points)
    {
        currentScore += points;
    }
    #endregion
}
