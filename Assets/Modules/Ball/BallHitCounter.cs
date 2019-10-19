using UnityEngine;

[DisallowMultipleComponent]
public class BallHitCounter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreManager.HitBallCounter++;
    }
}
