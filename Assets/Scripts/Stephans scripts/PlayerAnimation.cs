using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerController controller;
    public SpriteRenderer sprite;
    float moveTimer;
    public float timeToRun = 0.7f;

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

        float move = Input.GetAxisRaw("Horizontal");

        if (move > 0)
            GetComponent<SpriteRenderer>().flipX = false;
        else if (move < 0)
            GetComponent<SpriteRenderer>().flipX = true;


        // run delay logic
        if (speed > 0.1f && controller.isGrounded)
            moveTimer += Time.deltaTime;
        else
            moveTimer = 0f;

        anim.SetBool("IsRunning", moveTimer >= timeToRun);
    }
}

