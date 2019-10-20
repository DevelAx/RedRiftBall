using System;
using UnityEngine;

[DisallowMultipleComponent]
public class ScreenSizeWatcher : MonoBehaviour
{
    public static event Action ResolutionChanged;

    private Vector3Int _screen;

    private void Update()
    {
        if (_screen.x != Screen.width)
        {
            _screen.x = Screen.width;
            ResolutionChanged?.Invoke();
        }
    }
}
