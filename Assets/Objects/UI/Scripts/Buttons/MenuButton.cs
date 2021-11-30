using UnityEngine.SceneManagement;

public class MenuButton : Buttons
{
    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(Scenes.Menu);
    }
}
