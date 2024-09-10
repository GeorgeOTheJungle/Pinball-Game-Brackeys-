using UnityEngine;

public class ItemController : MonoBehaviour
{
    //Variables privadas
    [SerializeField] private float respawnTime = 5f;
    [SerializeField][Range(0f, 1f)] private float alpha = 0.5f;
    private CircleCollider2D CC;
    private SpriteRenderer SR;
    private PowerUpSelector PUS;
    private bool active = true;
    private float _respawnTime;

    private void Start()
    {
        //Asignacion de referencias
        CC = GetComponent<CircleCollider2D>();
        SR = GetComponent<SpriteRenderer>();
        PUS = GetComponent<PowerUpSelector>();

        _respawnTime = respawnTime;

        PUS.SelectPowerUp();
    }

    private void Update()
    {
        //If que gestiona la activacion del item
        if (!active)
        {
            _respawnTime -= Time.deltaTime;

            if (_respawnTime <= 0f)
            {
                ActivateItem();

                _respawnTime = respawnTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "GhostBall")
        {
            DeactivateItem();
            PUS.PowerUpObtained();

            //TEMPORAL
            PowerUps_Manager.Instance.ActivatePowerUp();
        }
    }

    //Funcion para desactivar el item
    private void DeactivateItem()
    {
        //Desactivar trigger, cambiar el alpha y actualizar el booleano
        CC.enabled = false;

        Color tmp = SR.color;
        tmp.a = alpha;
        SR.color = tmp;

        active = false;
    }

    //Funcion para activar el item
    private void ActivateItem()
    {
        //Activar trigger, cambiar el alpha, seleccionar el PowerUp y actualizar el booleano
        CC.enabled = true;

        Color tmp = SR.color;
        tmp.a = 1f;
        SR.color = tmp;

        PUS.SelectPowerUp();

        active = true;
    }
}
