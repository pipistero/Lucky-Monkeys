using UnityEngine;

public class TorpedaInput : MonoBehaviour
{
    [SerializeField] private TorpedasSpawner _torpedasSpawner;

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0))
       {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _torpedasSpawner.SpawnTorpeda(clickPosition);
        }
    }
}
