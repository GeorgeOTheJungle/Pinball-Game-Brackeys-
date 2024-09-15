using UnityEngine;

public class BadBall : MonoBehaviour
{
    //Variables privadas
    [SerializeField] private float timeLife = 10f;

    private void Update()
    {
        timeLife -= Time.deltaTime;

        if (timeLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
