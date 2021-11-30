using UnityEngine.UI;
using UnityEngine;

public class WinScreen : Screen 
{
    [Space]
    [Header("Texts")]
    [SerializeField] private Text _shipsDestroyed;

    public void SetShipsDestroyedCount(int count) { _shipsDestroyed.text = count.ToString(); }
}