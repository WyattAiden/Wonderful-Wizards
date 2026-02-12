using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        float horizontalSpeed = Mathf.Abs(rb2d.linearVelocity.x);
        anim.SetFloat("Speed", horizontalSpeed);



        bool isGrounded = Mathf.Abs(rb2d.linearVelocity.y) < 0.01f;
        anim.SetBool("IsGrounded", isGrounded);

        FlipSprite(rb2d.linearVelocity.x);

    }

    void FlipSprite(float moveX)
    {
        if (moveX > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

    }
}
