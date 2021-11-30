using UnityEngine.SceneManagement;
using UnityEngine;

public class StartLevelButton : Buttons
{
    [SerializeField] private int _levelNumber;

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(Scenes.Level + _levelNumber.ToString());
    }
}
