using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class SpawnOnlyOnce : MonoBehaviour
{
    [Header("Object Spawner")]
    [SerializeField] private ObjectSpawner objectSpawner;

    private bool hasSpawned = false;

    public void SpawnOnce(Vector3 position, Vector3 normal)
    {
        if (hasSpawned)
        {
            Debug.Log("Object already spawned. Ignoring new spawn.");
            return;
        }

        if (objectSpawner == null)
        {
            Debug.LogError("Object Spawner is missing. Please assign it in the Inspector.");
            return;
        }

        objectSpawner.TrySpawnObject(position, normal);

        hasSpawned = true;
    }

    public void ResetSpawn()
    {
        hasSpawned = false;
    }
}