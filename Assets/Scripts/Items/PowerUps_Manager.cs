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

    [Header("More Flippers")]
    public bool extraFlippers = false;

    //Variables privadas
    [Header("GhostBall PowerUp")]
    [SerializeField] private GameObject ghostBall_Prefab;
    [SerializeField] private Transform ghostBall_Spawn;

    [Header("ExitLock PowerUp")]
    [SerializeField] private GameObject lock_Prefab;
    [SerializeField] private Transform lock_Spawn;

    [Header("Penetracion Uffas")]
    [SerializeField] private int penetrationCharges = 3;

    private ScoreManager SM;

    private void Start()
    {
        SM = ScoreManager.Instance;
    }

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
                MoreDamage();
                
                inventory.RemoveAt(0);
                break;

            case 1:
                AddLife();
                inventory.RemoveAt(0);
                break;

            case 2:
                GhostBall();
                inventory.RemoveAt(0);
                break;

            case 3:
                ExitLock();
                inventory.RemoveAt(0);
                break;

            case 4:
                Penetration();
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

    //Funcion para aumentar los damages
    private void MoreDamage()
    {
        ballDamage++;
        GameManager.Instance.playerBall.GetComponent<Ball>().UpdateDamages();
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

    #region Shop
    //Funcion para setear el powerUp actual ya que las nenas de los botones no aceptan 2 entradas de variables en la funcion
    public void SetPowerUp(int itemID)
    {
        activePowerUp = itemID;
    }

    //Funcion para comprar un item en la tienda
    public void BuyItem(int itemCost)
    {
        if (SM.currentScore - itemCost >= 0)
        {
            //Si son mas damages o vida, usarlos automaticamente
            if (activePowerUp == 0 || activePowerUp == 1)
            {
                if (activePowerUp == 1 && SM.currentLife < 5)
                {
                    SM.AddLife();
                    SM.currentScore -= itemCost;
                }
                else if (activePowerUp == 0)
                {
                    MoreDamage();
                    SM.currentScore -= itemCost;
                }
            }
            else
            {
                SavePowerUp();
                SM.currentScore -= itemCost;
            }  
        }
        else
        {
            Debug.Log("Sos pobre");
        }
    }

    //Funcion de compra de los flippers extra
    public void ExtraFlippers(int itemCost)
    {
        if (SM.currentScore - itemCost >= 0)
        {
            extraFlippers = true;
            SM.currentScore -= itemCost;
        }   
    }
    #endregion
}
