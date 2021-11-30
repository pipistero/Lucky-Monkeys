using UnityEngine;

public class Menu : MonoBehaviour
{
    [Space]
    [Header("Screens")]
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private LevelsScreen _levelsScreen;

    [Space]
    [Header("Save Load system")]
    [SerializeField] private ParametersSaveLoad _parameters;

    private void Start()
    {
        _menuScreen.Open();
        _levelsScreen.Close();

        _menuScreen.SetDestroyedShips(_parameters.Load(Parameters.DestroyedShips));
    }

    public void StartGame()
    {
        _menuScreen.Close();
        _levelsScreen.Open();
    }
}
