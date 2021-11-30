using UnityEngine.SceneManagement;

public class RestartButton : Buttons
{
    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
