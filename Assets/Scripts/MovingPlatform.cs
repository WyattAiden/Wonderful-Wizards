using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float moveSpeed = 2f;

    private Transform target;

    void Start()
    {
        // start moving toward B first
        target = pointB;
    }

    void Update()
    {
        // move toward the current target
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            if (target == pointA)
            {
                target = pointB;
            }
            else
            {
                target = pointA;
            }
        }
    }
}