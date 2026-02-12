using UnityEngine;

public class UltimatePlatform : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private Collider2D Collider;
    [SerializeField] public bool isOn = false;
    [SerializeField] private State currentState = State.Triangle;
    [SerializeField] public bool isBallPlatform = true;

    [SerializeField] public bool isMovingPlatform;
    [SerializeField, Header("Moving Platform Settings")] public Transform pointA;
    [SerializeField] public Transform pointB;
    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 previousPosition;
    [HideInInspector] public Vector2 moveDiff;

    public enum State
    {
        Triangle,
        Square,
        Circle
    }
    private void Start()
    {
        previousPosition = transform.position;
        if (isMovingPlatform && pointB!= null)
        {
            target = pointB;
        }
    }
    private void FixedUpdate()
    {
        if (isOn)
        {
            Collider.enabled = true;
            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1f);
        }

        if (!isOn) 
        { 
            Collider.enabled = false;
            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.3f);
        }

        if (isMovingPlatform)
        {
            if (pointA == null || pointB == null)
            {
                Debug.Log("Point A/Point B on" + gameObject.name + "is null, assign A/B");
                return;
            }

            transform.position = Vector2.MoveTowards
            (
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
            Vector2 currentPos = transform.position;
            moveDiff = currentPos - previousPosition;
            previousPosition = currentPos;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isBallPlatform) return;
        if (currentState == State.Triangle)
        {
            if (collision.name == "Triangle Ball")
            {
                isOn = true;

                Debug.Log(currentState + " platform was enabled");
            }
        }

        else if (currentState == State.Square)
        {
            if (collision.name == "Square Ball")
            {
                isOn = true;

                Debug.Log(currentState + " platform was enabled");
            }
        }

        else if (currentState == State.Circle)
        {
            if (collision.name == "Circle Ball")
            {
                isOn = true;

                Debug.Log(currentState + " platform was enabled");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isBallPlatform) return;
        if (currentState == State.Triangle)
        {
            if (collision.name == "Triangle Ball")
            {
                isOn = false;

                Debug.Log(currentState + " platform was disabled");
            }
        }

        else if (currentState == State.Square)
        {
            if (collision.name == "Square Ball")
            {
                isOn = false;

                Debug.Log(currentState + " platform was disabled");
            }
        }

        else if (currentState == State.Circle)
        {
            if (collision.name == "Circle Ball")
            {
                isOn = false;

                Debug.Log(currentState + " platform was disabled");
            }
        }
    }


}
