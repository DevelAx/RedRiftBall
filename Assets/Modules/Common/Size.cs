using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Size : MonoBehaviour
{
    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        Width = renderer.bounds.size.x;
        Height = renderer.bounds.size.y;
    }

    #region Interface

    public float Width { get; private set; }
    public float Height { get; private set; }

    #endregion
}
