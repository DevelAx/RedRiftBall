using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BallBounceSound : MonoBehaviour
{
    public AudioSource BallHitAudioSource;

    private Rigidbody2D _rigidbody;
    private float _gravitySqr;

    private void Awake()
    {
        if (!BallHitAudioSource)
            BallHitAudioSource = this.RequireComponent<AudioSource>();

        _rigidbody = GetComponent<Rigidbody2D>();
        _gravitySqr = Physics2D.gravity.sqrMagnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallHitAudioSource.volume = _rigidbody.velocity.sqrMagnitude / _gravitySqr;
        BallHitAudioSource.pitch = 0.8f + BallHitAudioSource.volume / 4;
        BallHitAudioSource.Stop();
        BallHitAudioSource.Play();
    }
}
