using UnityEngine.UI;
using UnityEngine;

public class GameScreen : Screen
{
    [Space]
    [Header("Texts")]
    [SerializeField] private Text _shipsCount;
    [SerializeField] private Text _torpedasCount;

    public void SetShipsCount(int count) { _shipsCount.text = count.ToString(); }

    public void SetTorpedasCount(int count) { _torpedasCount.text = count.ToString(); }
}
