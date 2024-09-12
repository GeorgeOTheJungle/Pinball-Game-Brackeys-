using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfiguration : MonoBehaviour
{
    public static GameConfiguration Instance;

    public float FlipperForce = 7500f;
    public float BumperAdditionalForce = 10000f;

    private void Awake()
    {
        Instance = this;
    }
}
