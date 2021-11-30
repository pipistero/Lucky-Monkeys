using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [Space]
    [Header("Pool parameters")]
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initalize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var spawnedObject = Instantiate(prefab, _container);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableInvisibleObjects()
    {
        Vector3 disablePoint = Camera.main.ViewportToWorldPoint(new Vector2(-0.3f, 1.3f));

        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                Vector3 itemPosition = item.transform.position;

                if (itemPosition.x <= disablePoint.x || itemPosition.y > disablePoint.y)
                {
                    item.SetActive(false);
                }
            }
        }   
    }
}
