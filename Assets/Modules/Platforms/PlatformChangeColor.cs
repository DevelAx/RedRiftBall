using UnityEngine;

[DisallowMultipleComponent]
public class PlatformChangeColor : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color[] _colors = new[] { Color.green, Color.yellow, Color.red, Color.magenta, Color.cyan, Color.black };
    private int _colorIndex;

    private void Awake()
    {
        _spriteRenderer = this.RequireComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeColor();
    }

    #region Helpers

    private void ChangeColor()
    {
        _spriteRenderer.color = _colors[_colorIndex++];

        if (_colorIndex >= _colors.Length)
            _colorIndex = 0;
    }

    #endregion
}
