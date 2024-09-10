using UnityEngine;

public class PowerUpSelector : MonoBehaviour
{
    //Variables privadas
    [SerializeField] private int actualPowerUp;
    [SerializeField] private int amountOfPowerUps;

    //Funcion para seleccionar un powerUp aleatorio
    public void SelectPowerUp()
    {
        actualPowerUp = Random.Range(0, amountOfPowerUps - 1);
    }

    //Funcion para indicar el power up obtenido 
    public void PowerUpObtained()
    {
        PowerUps_Manager.Instance.activePowerUp = actualPowerUp;
    }
}
