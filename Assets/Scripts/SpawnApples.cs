using UnityEngine;

public class SpawnApples : MonoBehaviour, EventInterface
{
    public GameObject applePrefab;
    [Tooltip ("Location where apples spawn")]public Transform tree;
    public float appleSpacing = 0.5f;
    private bool hasSpawned = false;
    public void OnInteract(PlayerController player)
    { if (!hasSpawned)
        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnOffset = new Vector3((i * appleSpacing) - appleSpacing, 0f, 0f);
            Instantiate
                (
                applePrefab,
                tree.position + spawnOffset,
                Quaternion.identity
                );
        }
        hasSpawned = true;
    }
}