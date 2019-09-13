using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Public Static

    public static int HitBallCounter;

    #endregion

    private static ScoreManager Instance;
    private static readonly GUIStyle _guiStyle = new GUIStyle();

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

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
}
