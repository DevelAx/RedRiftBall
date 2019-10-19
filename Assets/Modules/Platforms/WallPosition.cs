using System;
using UnityEngine;

[DisallowMultipleComponent]
public class WallPosition : MonoBehaviour
{
    public enum Positions
    {
        Left,
        Right
    }

    public Positions Position;
    private float _halfWidth;

    private void Awake()
    {
        ScreenSizeWatcher.ResolutionChanged += GameController_ResolutionChanged;
    }

    private void Start()
    {
        Size size = GetComponent<Size>();
        _halfWidth = size.Width / 2;
    }

    private void GameController_ResolutionChanged()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector3 stageSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 pos = transform.position;

        switch (Position)
        {
            case Positions.Left:
                pos.x = -stageSize.x - _halfWidth;
                break;
            case Positions.Right:
                pos.x = stageSize.x + _halfWidth;
                break;
            default:
                throw new Exception($"Unexpected wall position: {Position}");
        }

        transform.position = pos;
    }
}
