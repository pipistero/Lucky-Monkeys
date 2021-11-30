using UnityEngine.Events;
using UnityEngine;

public class TorpedasSpawner : ObjectsPool
{
    [Space]
    [Header("Prefab")]
    [SerializeField] private GameObject _template;

    [Space]
    [Header("Other")]
    [SerializeField] private Game _game;

    public event UnityAction TorpedaSpawned;

    private Vector2 _spawnPoint;
    private Camera _camera;

    private int _count;

    private void Start()
    {
        Initalize(_template);

        _camera = Camera.main;

        _spawnPoint = _camera.ScreenToWorldPoint(new Vector2(_camera.pixelWidth / 2, 0));

        _count = _game.TorpedasCount();
    }

    public void SpawnTorpeda(Vector2 clickPoint)
    {
        if (TryGetObject(out GameObject torpeda) && _count > 0)
        {
            torpeda.SetActive(true);
            torpeda.transform.position = _spawnPoint;
            torpeda.GetComponent<TorpedaMover>().SetDirectionToMove(_spawnPoint, clickPoint);
            torpeda.GetComponent<TorpedaRotator>().SetRotationWithDirection(_spawnPoint, clickPoint);

            _count -= 1;

            TorpedaSpawned?.Invoke();
        }

        DisableInvisibleObjects();
    }
}
