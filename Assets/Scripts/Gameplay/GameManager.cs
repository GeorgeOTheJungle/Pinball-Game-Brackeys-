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

    //Funcion para iniciar el juego
    public void StartGame()
    {
        isPlaying = true;

        //FUNCIONES PARA INICIAR EL JUEGO
        //Spawnear bola, habilitar inputs etc.
    }

    //Funcion para terminar el juego
    public void GameOver()
    {

    }
}
