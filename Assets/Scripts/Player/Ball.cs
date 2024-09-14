using UnityEngine;

public class Ball : MonoBehaviour
{
    //Variables publicas
    public int damage = 0;

    private void Start()
    {
        UpdateDamages();
    }

    public void OnBallLost()
    {
        GameManager.Instance.SpawnABall();
    }

    //Funcion para actualizar los damages
    public void UpdateDamages()
    {
        damage = PowerUps_Manager.Instance.ballDamage;
    }
}
