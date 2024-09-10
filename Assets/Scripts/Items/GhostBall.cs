using UnityEngine;

public class GhostBall : MonoBehaviour
{
    //Variables privadas
    [SerializeField] private float lifeTime = 15f;
    [SerializeField] private float yLimit = -7f;

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        //Funcion que evalua la destruccion de la bola
        if (lifeTime <= 0f || transform.position.y <= yLimit)
        {
            Destroy(gameObject);
        }
    }
}
