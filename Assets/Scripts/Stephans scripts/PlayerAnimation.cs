using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    PlayerController controller;

    float moveTimer;
    public float timeToRun = 0.8f; // how long before run starts

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        float speed = Mathf.Abs(rb.linearVelocity.x);

        anim.SetFloat("Speed", speed);
        anim.SetFloat("YVelocity", rb.linearVelocity.y);
        anim.SetBool("IsGrounded", controller.isGrounded);

        // running timer logic
        if (speed > 0.1f && controller.isGrounded)
        {
            moveTimer += Time.deltaTime;
        }
        else
        {
            moveTimer = 0f;
        }

        anim.SetBool("IsRunning", moveTimer >= timeToRun);
    }
}
