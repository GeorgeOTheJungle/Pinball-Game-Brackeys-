using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    //Variables privadas
    [SerializeField] private int hitsToDestroy = 3;
    [SerializeField] private float timeToRebuild = 5f;

    [Header("BossWall Options")]
    [SerializeField] private bool isFromBoss = false;
    [SerializeField] private float timeLife = 30f;

    private PowerUps_Manager PU_Manager;
    private SpriteRenderer SR;
    private BoxCollider2D BC;
    private bool destroyed = false;
    private float _timeToRebuild;
    private int _hitsToDestroy;

    private void Start()
    {
        PU_Manager = PowerUps_Manager.Instance;
        SR = GetComponent<SpriteRenderer>();
        BC = GetComponent<BoxCollider2D>();
        _hitsToDestroy = hitsToDestroy;
    }

    private void Update()
    {
        //Definir comportamiento dependiendo de si es muro de jefe o de nivel
        if (isFromBoss)
        {
            timeLife -= Time.deltaTime;

            if (timeLife <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (destroyed)
            {
                _timeToRebuild -= Time.deltaTime;

                if (_timeToRebuild <= 0f)
                {
                    RebuildBlock();
                }
            }
        } 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Comprobacion de tag
        if (other.collider.CompareTag("Ball"))
        {
            //Comprobar si tiene el efecto de penetracion
            if (PU_Manager.penetration)
            {
                PU_Manager._penetrationCharge--;

                if (PU_Manager._penetrationCharge <= 0)
                {
                    PU_Manager.penetration = false;
                }

                DestroyBlock();
            }
            else
            {
                _hitsToDestroy--;

                if (_hitsToDestroy <= 0)
                {
                    DestroyBlock();
                }
            }
        }
    }

    //Funcion para "destruir" el bloque
    private void DestroyBlock()
    {
        if (isFromBoss)
        {
            Destroy(gameObject);
        }
        else
        {
            _timeToRebuild = timeToRebuild;

            //Hacerlo transparente y sin colisiones
            Color tmp = SR.color;
            tmp.a = 0f;
            SR.color = tmp;

            BC.enabled = false;

            destroyed = true;
        }
    }

    //Funcion para reconstruir el bloque
    private void RebuildBlock()
    {
        _hitsToDestroy = hitsToDestroy;

        //Hacerlo visible y con colisiones
        Color tmp = SR.color;
        tmp.a = 1f;
        SR.color = tmp;

        BC.enabled = true;

        destroyed = false;
    }
}
