using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Space]
    [Header("Spawners")]
    [SerializeField] private ShipsSpawner _shipsSpawner;
    [SerializeField] private TorpedasSpawner _torpedasSpawner;
    [SerializeField] private EffectsSpawner _effectsSpawner;

    [Space]
    [Header("UI")]
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private LoseScreen _loseScreen;
    [SerializeField] private WinScreen _winScreen;

    [Space]
    [Header("Game Parameters")]
    [SerializeField] private int _torpedasCount;
    [SerializeField] private int _shipsDestroyToWin;

    [Space]
    [Header("Save Load system")]
    [SerializeField] private ParametersSaveLoad _parameters;

    private int _shipsDestroyed = 0;

    private void OnEnable() { _torpedasSpawner.TorpedaSpawned += OnTorpedaSpawned; }

    private void OnDisable() { _torpedasSpawner.TorpedaSpawned -= OnTorpedaSpawned; }

    private void Start()
    {
        _gameScreen.Open();
        _loseScreen.Close();
        _winScreen.Close();

        _gameScreen.SetShipsCount(0);
        _gameScreen.SetTorpedasCount(_torpedasCount);

        _winScreen.SetShipsDestroyedCount(_shipsDestroyToWin);

        _loseScreen.SetShipsDestroyedCount(0);
    }

    public void ShipDestroyed(Ship ship)
    {
        _shipsDestroyed += 1;

        _effectsSpawner.Spawn(ship.transform.position);

        _gameScreen.SetShipsCount(_shipsDestroyed);
        _loseScreen.SetShipsDestroyedCount(_shipsDestroyed);

        if (_shipsDestroyed == _shipsDestroyToWin)
        {
            Win();
            SaveShipsCount(_shipsDestroyToWin);
        }
    }

    public int TorpedasCount()
    {
        return _torpedasCount;
    }

    private void OnTorpedaSpawned()
    {
        _torpedasCount -= 1;

        _gameScreen.SetTorpedasCount(_torpedasCount);

        if (_torpedasCount == 0)
        {
            Lose();
            SaveShipsCount(_shipsDestroyed);
        }
    }

    private void Win()
    {
        _gameScreen.Close();
        _winScreen.Open();
    }

    private void Lose()
    {
        _gameScreen.Close();
        _loseScreen.Open();
    }

    private void SaveShipsCount(int count)
    {
        int _currentDestroyedShips = _parameters.Load(Parameters.DestroyedShips);
        _currentDestroyedShips += count;
        _parameters.Save(Parameters.DestroyedShips, _currentDestroyedShips);
    }
}
