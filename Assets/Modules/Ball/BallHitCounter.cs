using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitCounter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreManager.HitBallCounter++;
    }
}
