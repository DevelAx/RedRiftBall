using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static PlanetParams PlanetParams { get; private set; }

    private static SceneLoader Instance;

    private static bool _inStartMenu = true;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (_inStartMenu)
            {
                Application.Quit();
                return;
            }

            SceneManager.LoadScene(Constants.SceneNames.Start);
            InStart(true);
        }
    }

    #region Custom Public

    public void ChangePlanet(ButtonPlanetConfig newPlanetConfig)
    {
        PlanetParams = newPlanetConfig.Params;
        SceneManager.LoadScene(Constants.SceneNames.Planet);
        InStart(false);
    }

    #endregion

    #region Helpers

    private void InStart(bool on)
    {
        _inStartMenu = on;
    }

    #endregion
}
