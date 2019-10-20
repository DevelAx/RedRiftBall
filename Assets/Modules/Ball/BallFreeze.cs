using UnityEngine;

[DisallowMultipleComponent]
public class BallFreeze : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = this.RequireComponent<Rigidbody2D>();
        Menu.AddDependant(this);
    }
    private void OnEnable()
    {
        _rigidbody.simulated = true;
    }

    private void OnDisable()
    {
        _rigidbody.simulated = false;
    }
}
