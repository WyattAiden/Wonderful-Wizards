using UnityEngine;

public class SpawnApples : MonoBehaviour, EventInterface
{
    public GameObject applePrefab;
    [Tooltip ("Location where apples spawn")]public Transform tree;
    public float appleSpacing = 0.8f;
    private bool hasSpawned = false;
    private float spawnTimer = 0;
    public float pourDuration = 1f;
    public bool timeToTick = false;

    public MustExist appleRe;
    public MustExist appleRe2;
    public MustExist appleRe3;

    public ParticleSystem waterParticles;
    public void OnInteract(PlayerController player)
    {
        if (!hasSpawned) timeToTick = true;

        waterParticles.Play();
        
    }

    private void Update()
    {
        if (timeToTick) spawnTimer += Time.deltaTime;

        if (spawnTimer > pourDuration & timeToTick)
        {
            for (int i = 0; i < 3; i++)
            {

                Vector3 spawnOffset = new Vector3((i * appleSpacing) - appleSpacing, 0f, 0f);
                GameObject spawnedApple = Instantiate
                    (
                    applePrefab,
                    tree.position + spawnOffset,
                    Quaternion.identity
                    );

                if (i == 0)
                {
                    appleRe.target = spawnedApple;
                    appleRe.canSpawn = true;
                }
                else if (i == 1)
                {
                    appleRe2.target = spawnedApple;
                    appleRe2.canSpawn = true;
                }
                else if (i == 2)
                {
                    appleRe3.target = spawnedApple;
                    appleRe3.canSpawn = true;
                }
            }

            hasSpawned = true;

            timeToTick = false;
            spawnTimer = 0;
        }
    }
}