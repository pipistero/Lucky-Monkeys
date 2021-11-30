using UnityEngine;

public class TorpedaRotator : MonoBehaviour
{
    public void SetRotationWithDirection(Vector2 spawnPoint, Vector2 clickPoint)
    {
        Vector3 direction = (clickPoint - spawnPoint).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90 + 7;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
