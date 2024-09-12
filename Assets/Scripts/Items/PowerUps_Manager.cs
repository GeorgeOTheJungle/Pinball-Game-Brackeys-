using System.Collections.Generic;
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
    public bool collectionPhase = true;

    [Header("PowerUp Inventory")]
    public int activePowerUp;
    public List<int> inventory = new List<int>();

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

    //Funcion para guardar un power up en el inventario
    public void SavePowerUp()
    {
        inventory.Add(activePowerUp);
    }

    //Funcion para activar el power up
    public void ActivatePowerUp()
    {
        switch (inventory[0])
        {
            case 0:
                GhostBall();
                inventory.RemoveAt(0);
                break;

            case 1:
                ExitLock();
                inventory.RemoveAt(0);
                break;

            case 2:
                MoreDamage();
                inventory.RemoveAt(0);
                break;

            case 3:
                Penetration();
                inventory.RemoveAt(0);
                break;

            case 4:
                AddLife();
                inventory.RemoveAt(0);
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
