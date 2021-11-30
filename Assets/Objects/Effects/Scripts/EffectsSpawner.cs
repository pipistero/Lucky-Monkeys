using System.Collections;
using UnityEngine;

public class EffectsSpawner : ObjectsPool
{
    [Space]
    [Header("Prefab")]
    [SerializeField] private GameObject _template;

    private void Start() { Initalize(_template); }

    public void Spawn(Vector3 spawnPoint)
    {
        if (TryGetObject(out GameObject effect))
        {
            effect.SetActive(true);
            effect.transform.position = spawnPoint;

            ParticleSystem particleSystem = effect.GetComponent<ParticleSystem>();

            particleSystem.Play();
            StartCoroutine(DisableEffect(effect, particleSystem.main.duration + 0.2f));
        }
    }

    private IEnumerator DisableEffect(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);

        effect.SetActive(false);
    }
}
