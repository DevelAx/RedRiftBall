using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;

    #region MonoBehaviour

    private void Awake()
    {
        this.Assert(ScoreText);
    }

    private void Update()
    {
        ScoreText.text = HitBallCounter.ToString();
    }

    #endregion

    #region Public Static

    public static int HitBallCounter;

    #endregion
}
