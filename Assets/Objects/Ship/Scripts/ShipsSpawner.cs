using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsSpawner : ObjectsPool
{
    [Space]
    [Header("Prefab")]
    [SerializeField] private GameObject _template;

    [Space]
    [Header("Spawner parameters")]
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _bordersSizeInPixels;

    [Space]
    [Header("Spawn sides")]
    [SerializeField] private bool _shipsFromLeft;
    [SerializeField] private bool _shipsFromRight;

    [Space]
    [Header("Other")]
    [SerializeField] private Game _game;

    private Camera _camera;

    private List<float> _xPositions = new List<float> { 0, 0 };
    private List<float> _yPositions = new List<float> { 0, 0 };

    private int _sides;
    private int _currentShipDirection = 0;

    private void Start()
    {
        Initalize(_template);

        _camera = Camera.main;

        if (_shipsFromLeft && _shipsFromRight) _sides = 2;
        else _sides = 1;

        SetSpawnPositions();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Vector3 spawnPoint = GenerateSpawnPoint();

        yield return new WaitForSeconds(_timeBetweenSpawn);

        if (TryGetObject(out GameObject ship))
        {
            ship.SetActive(true);
            ship.transform.position = spawnPoint;
            ship.GetComponent<ShipMover>().SetXDirection(_currentShipDirection);
        }

        DisableInvisibleObjects();
        StartCoroutine(Spawn());
    }

    private Vector3 GenerateSpawnPoint()
    {
        float xPosition = 0;

        if (_sides == 2)
        {
            if (Random.Range(0, 3) == 0)
            {
                _currentShipDirection = 1;
                xPosition = _xPositions[0];
            }
            else
            {
                _currentShipDirection = -1;
                xPosition = _xPositions[1];
            }
        }
        else
        {
            if (_shipsFromLeft)
            {
                _currentShipDirection = 1;
                xPosition = _xPositions[0];
            }
            else
            {
                _currentShipDirection = -1;
                xPosition = _xPositions[1];
            }
        }
        
        return new Vector3(xPosition, Random.Range(_yPositions[0], _yPositions[1]), 0);
    }

    private void SetSpawnPositions()
    {
        _yPositions[0] = _camera.ScreenToWorldPoint(new Vector2(0, _camera.pixelHeight - _bordersSizeInPixels)).y;
        _yPositions[1] = _camera.ScreenToWorldPoint(new Vector2(0, _bordersSizeInPixels)).y;

        _xPositions[0] = _camera.ScreenToWorldPoint(new Vector2(-200, 0)).x;
        _xPositions[1] = _camera.ScreenToWorldPoint(new Vector2(_camera.pixelWidth + 200, 0)).x;
    }
}
