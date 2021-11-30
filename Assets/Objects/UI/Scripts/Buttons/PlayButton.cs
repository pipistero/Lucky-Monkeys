using UnityEngine;

public class PlayButton : Buttons
{
    [SerializeField] private Menu _menu;

    protected override void OnButtonClick()
    {
        _menu.StartGame();
    }
}
