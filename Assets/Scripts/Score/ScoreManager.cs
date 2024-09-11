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
    public int currentScore = 0;

    //Funcion para sumar puntos
    public void PointsToAdd(int points)
    {
        currentScore += points;
    }
}
