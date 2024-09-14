using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    #region Singleton
    public static UI_Manager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    //Variables privadas
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI ballsUI;
    [SerializeField] private TextMeshProUGUI shopScoreUI;
    [SerializeField] private TextMeshProUGUI gameOverUI;
    private ScoreManager SM;

    private void Start()
    {
        SM = ScoreManager.Instance;
    }

    //Funcion que gestiona lo que se ve en la UI dentro del juego
    private void OnGUI()
    {
        scoreUI.text = SM.currentScore.ToString();
        ballsUI.text = "x" + SM.currentLife.ToString();
        shopScoreUI.text = SM.currentScore.ToString();
    }

    //Funcion para salir del juego
    public void ExitGame()
    {
        Application.Quit();
    }

    //Funcion para reiniciar el juego
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    //Funcion para mostrar el menu de GameOver
    public void ShowGameOver()
    {
        gameOverUI.gameObject.SetActive(true);
    }
}
