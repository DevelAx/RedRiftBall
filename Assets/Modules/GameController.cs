using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Awake()
    {
        Physics2D.gravity = Vector2.down * SceneLoader.PlanetParams.Gravity;
        Camera.main.backgroundColor = SceneLoader.PlanetParams.SkyColor;
    }
}
