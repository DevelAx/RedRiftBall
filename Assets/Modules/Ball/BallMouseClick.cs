using UnityEngine;

[DisallowMultipleComponent]
public class BallMouseClick : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector3 _mousePos;
    private Vector2? _forceDirection;

    #region MonoBehaviour

    private void Awake()
    {
        _rigidbody = this.RequireComponent<Rigidbody2D>();
        Menu.AddDependant(this);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _forceDirection = new Vector2(_mousePos.x, _mousePos.y) - _rigidbody.position;
        }
        else
        {
            _forceDirection = null;
        }
    }

    private void FixedUpdate()
    {
        if (_forceDirection == null)
            return;

        Vector2 force = _forceDirection.Value.normalized * GameManager.GravityMagnitude * 0.9f;

        if (force.y < 0)
            force.y *= 0.5f; // Slow down when leaning down.

        _rigidbody.AddForce(force);
    }

    #endregion

    #region Helpers

    private void OnDrawGizmos()
    {
        if (_forceDirection == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(_rigidbody.position, _rigidbody.position + _forceDirection.Value);
    }

    #endregion
}
