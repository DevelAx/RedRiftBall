using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public Menu Menu;

    private static bool _inMenu = true;

    #region MonoBehaviour

    private void Awake()
    {
        this.Assert(Menu);
        ShowMenu();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_inMenu)
            {
                MyApp.Quit();
                return;
            }

            ShowMenu();
        }
    }

    #endregion

    #region Public

    public void ChangePlanet(ButtonPlanetConfig newPlanetConfig)
    {
        Menu.Hide();
        PlanetParams opts = newPlanetConfig.Params;
        Physics2D.gravity = Vector2.down * opts.Gravity;
        Camera.main.backgroundColor = opts.SkyColor;
        _inMenu = false;
    }

    #endregion

    #region Helpers

    private void ShowMenu()
    {
        Physics2D.gravity = Vector2.zero;
        Menu.Show();
        _inMenu = true;
    }

    #endregion
}
