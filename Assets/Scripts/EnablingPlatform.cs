using UnityEngine;

public class EnablingPlatform : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private Collider2D Collider;
    [SerializeField] private bool isOn = false;
    [SerializeField] private State currentState = State.Triangle;
    public enum State
    {
        Triangle,
        Square,
        Circle
    }

    private void Start()
    {
    }

    private void Update()
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentState == State.Triangle)
        {
            if (collision.name == "Triangle Ball")
            {
                isOn = true;

                Debug.Log(currentState + " platform was enabled");
            }
        }

        if (currentState == State.Square)
        {
            if (collision.name == "Square Ball")
            {
                isOn = true;

                Debug.Log(currentState + " platform was enabled");
            }
        }

        if (currentState == State.Circle)
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
        if (currentState == State.Triangle)
        {
            if (collision.name == "Triangle Ball")
            {
                isOn = false;

                Debug.Log(currentState + " platform was disabled");
            }
        }

        if (currentState == State.Square)
        {
            if (collision.name == "Square Ball")
            {
                isOn = false;

                Debug.Log(currentState + " platform was disabled");
            }
        }

        if (currentState == State.Circle)
        {
            if (collision.name == "Circle Ball")
            {
                isOn = false;

                Debug.Log(currentState + " platform was disabled");
            }
        }
    }
}
