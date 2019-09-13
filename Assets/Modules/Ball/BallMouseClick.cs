using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMouseClick : MonoBehaviour
{
    public int ForceFactor = 30;

    private Rigidbody2D _rigidbody;
    private Vector2 _forceDirection;
    private IEnumerator _coroutine;
    private float _gravity;
    private float _maxBallSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _gravity = Physics2D.gravity.magnitude;
        _maxBallSpeed = _gravity * _gravity;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _forceDirection = new Vector2(mousePos.x, mousePos.y) - _rigidbody.position;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = AddForceGradually();
            StartCoroutine(_coroutine);
        }
    }

    #region Helpers

    private IEnumerator AddForceGradually()
    {
        for (int i = 0; i < ForceFactor; i++)
        {
            _rigidbody.AddForce(_forceDirection.normalized * Mathf.Max(5f, _gravity));
            yield return null;
        }
    }

    #endregion
}
