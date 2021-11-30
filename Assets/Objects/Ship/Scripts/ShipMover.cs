using UnityEngine;

public class ShipMover : MonoBehaviour
{
    [Space]
    [Header("Parameters")]
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetXDirection(int xDirection)
    {
        _direction = new Vector3(xDirection, 0, 0);
    }
}