using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Ball.Instance.BallState == BallGameState.idle) Ball.Instance.BallState = BallGameState.playing;
    }
}
