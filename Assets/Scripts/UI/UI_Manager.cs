using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    //Variables privadas
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI ballsUI;
    [SerializeField] private TextMeshProUGUI shopScoreUI;
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
}
