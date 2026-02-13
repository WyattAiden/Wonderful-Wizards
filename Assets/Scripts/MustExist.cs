using UnityEngine;

public class MustExist : MonoBehaviour
{
    public GameObject target;
    public GameObject targetPrefab;

    void Update()
    {
        if (target == null)
        {
            target = Instantiate(targetPrefab, transform.position, Quaternion.identity);
        }
    }
}
