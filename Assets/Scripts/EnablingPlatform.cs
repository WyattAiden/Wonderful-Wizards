using UnityEngine;

public class EnablingPlatform : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private Collider2D Collider;
    [SerializeField] public bool isOn = false;
    [SerializeField] private State currentState = State.Triangle;
    [SerializeField] public bool isBallPlatform = true;
    public enum State
    {
        Triangle,
        Square,
        Circle
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
