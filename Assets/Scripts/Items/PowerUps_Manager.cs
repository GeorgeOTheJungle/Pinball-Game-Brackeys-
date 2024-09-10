using UnityEngine;

public class PowerUps_Manager : MonoBehaviour
{
    #region Singleton
    public static PowerUps_Manager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    //Variables publicas
    public int activePowerUp;

    //Variables privadas
    [Header ("GhostBall PowerUp")]
    [SerializeField] private GameObject ghostBall_Prefab;
    [SerializeField] private Transform ghostBall_Spawn;

    [Header("ExitLock PowerUp")]
    [SerializeField] private GameObject lock_Prefab;
    [SerializeField] private Transform lock_Spawn;

    //Funcion para activar el power up
    public void ActivatePowerUp()
    {
        switch (activePowerUp)
        {
            case 0:
                GhostBall();
                break;

            case 1:
                ExitLock();
                break;

            case 2:
                MoreDamage();
                break;

            case 3:
                Penetration();
                break;
        }
    }

    #region Power Ups
    //Funcion para crear una bola fantasmal
    private void GhostBall()
    {
        Instantiate(ghostBall_Prefab, ghostBall_Spawn.transform.position, Quaternion.identity);
    }

    //Funcion para crear un bloqueo en la salida
    private void ExitLock()
    {
        Debug.Log("Salida bloqueada");
    }

    //Funcion para crear mas flippers
    private void MoreDamage()
    {
        Debug.Log("Mas damages");
    }

    //Funcion para que la bola penetre
    private void Penetration()
    {
        Debug.Log("Buena penetracion");
    }
    #endregion
}
