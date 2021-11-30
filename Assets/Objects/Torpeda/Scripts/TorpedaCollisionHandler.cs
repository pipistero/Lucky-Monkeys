using UnityEngine;

public class TorpedaCollisionHandler : MonoBehaviour
{
    private Game _game;

    private void Start()
    {
        _game = FindObjectOfType<Game>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ship ship))
        {
            ship.Die();
            _game.ShipDestroyed(ship);
            gameObject.SetActive(false);
        }
    }
}
