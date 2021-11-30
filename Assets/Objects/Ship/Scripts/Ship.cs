using UnityEngine;

public class Ship : MonoBehaviour
{
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
