using UnityEngine;

public class TorpedaMover : MonoBehaviour
{
    [Space]
    [Header("Parameters")]
    [SerializeField] private float _speed;
    
    private Vector3 _direction;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetDirectionToMove(Vector2 spawnPoint, Vector2 pointToMove)
    {
        _direction = (pointToMove - spawnPoint).normalized;
    }
}
