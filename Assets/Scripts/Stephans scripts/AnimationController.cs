using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    public PlayerController playerController;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        player  = GetComponent<PlayerController>();
    }


    void Update()
    {

        float horizontalSpeed = Mathf.Abs(rb2d.linearVelocity.x);
        anim.SetFloat("Speed", horizontalSpeed);



        if (playerController.isGrounded) anim.SetBool("IsGrounded", isGrounded);

    }

}
