using UnityEngine;

public class ParametersSaveLoad : MonoBehaviour
{
    public int Load(string parameter)
    {
        return PlayerPrefs.GetInt(parameter);
    }

    public void Save(string parameter, int number)
    {
        PlayerPrefs.SetInt(parameter, number);
    }
}
