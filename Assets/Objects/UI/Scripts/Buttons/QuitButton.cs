using UnityEngine;

public class QuitButton : Buttons
{
    protected override void OnButtonClick()
    {
        Application.Quit();
    }
}
