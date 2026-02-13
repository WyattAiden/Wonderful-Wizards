using UnityEngine;

public class MustExist : MonoBehaviour
{
    public GameObject target;
    public GameObject targetPrefab;
    public bool canSpawn = false;

    void Update()
    {
        if (target == null && canSpawn)
        {
            target = Instantiate(targetPrefab, transform.position, Quaternion.identity);
        }
    }
}
