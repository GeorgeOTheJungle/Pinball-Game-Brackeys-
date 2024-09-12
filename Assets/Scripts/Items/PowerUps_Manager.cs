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

    [Header("Damages Locos")]
    public int ballDamage = 0;

    [Header("Penetracion OwO")]
    public bool penetration = false;
    public int _penetrationCharge = 0;

    //Variables privadas
    [Header("GhostBall PowerUp")]
    [SerializeField] private GameObject ghostBall_Prefab;
    [SerializeField] private Transform ghostBall_Spawn;

    [Header("ExitLock PowerUp")]
    [SerializeField] private GameObject lock_Prefab;
    [SerializeField] private Transform lock_Spawn;

    [Header("Penetracion Uffas")]
    [SerializeField] private int penetrationCharges = 3;

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

            case 4:
                AddLife();
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
        Instantiate(lock_Prefab, lock_Spawn.transform.position, Quaternion.identity);
    }

    //Funcion para crear mas flippers
    private void MoreDamage()
    {
        ballDamage++;
    }

    //Funcion para que la bola penetre
    private void Penetration()
    {
        penetration = true;
        _penetrationCharge = penetrationCharges;
    }

    //Funcion para agregar una bola al jugador
    private void AddLife()
    {
        ScoreManager.Instance.AddLife();
    }
    #endregion
}
