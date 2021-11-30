using UnityEngine.UI;
using UnityEngine;

public class MenuScreen : Screen 
{
    [Space]
    [Header("Texts")]
    [SerializeField] private Text _destroyedShipsCount;

    public void SetDestroyedShips(int count) { _destroyedShipsCount.text = count.ToString(); }
}