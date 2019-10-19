using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreManager : MonoBehaviour
{
    private static readonly GUIStyle _guiStyle = new GUIStyle();

    #region MonoBehaviour

    private void Awake()
    {
        _guiStyle.fontSize = 26;
        _guiStyle.normal.textColor = Color.black;
    }

    private void OnGUI()
    {
        string text = "Hits: " + HitBallCounter;
        GUIContent content = new GUIContent(text);
        Vector2 textSize = _guiStyle.CalcSize(content);
        float margin = 15;
        Rect pos = new Rect(Screen.width - textSize.x - margin, margin, textSize.x, textSize.y);
        GUI.Label(pos, content, _guiStyle);
    }

    #endregion

    #region Public Static

    public static int HitBallCounter;

    #endregion
}
