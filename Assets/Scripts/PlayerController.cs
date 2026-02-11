using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public int playerNumber { get; private set; }
    [field: SerializeField] public Color playerColor { get; private set; }
    [field: SerializeField] public SpriteRenderer spriteRenderer { get; private set; }
    [field: SerializeField] public Rigidbody2D rb2d { get; private set; }
    [field: SerializeField] public float moveSpeed { get; private set; } = 10f;
    [field: SerializeField] public bool isMirror { get; private set; } = false;

    [Header("Jump Things")] //This adds a text header above a section
    [field: SerializeField] public float jumpHeight { get; private set; } = 5f;
    [field: SerializeField] public float fallMultiplier { get; private set; } = 5f;   //Scalar to increase fall speed
    [field: SerializeField] public float lowJumpMultiplier { get; private set; } = 1.5f;
    //Low jump multiplier for tapping jump vs holding jump
    //Coyote time AKA "ledge forgiveness"   
    [field: SerializeField] public float coyoteTimeMax { get; private set; } = 0.25f;
    [field: SerializeField] public float coyoteTime { get; private set; } = 0f;
    [field: SerializeField] public float dropStartSpeed { get; private set; } = 2f;
    //Bool to check if the player is on the ground and a LayerMask
    [field: SerializeField] public bool isGrounded { get; private set; } = false;
    [field: SerializeField] public LayerMask groundLayer { get; private set; }   //List of layers. There are 5 by default
    [field: SerializeField] public Transform feet { get; private set; }  //Feet Transform.
    [field: SerializeField] public float groundCheckRay { get; private set; } = 0.25f;
    [field: SerializeField] public bool inInteractRange { get; private set; } = false;
    [field: SerializeField] public AreaInteract interactTarget { get; private set; } = null;
    [field: SerializeField] public bool dead { get; private set; } = false;

    // Player input information
    private PlayerInput PlayerInput;
    private InputAction InputActionMove;
    private InputAction InputActionJump;
    private InputAction InputActionInteract;

    // Assign color value on spawn from main spawner
    public void AssignColor(Color color)
    {
        // record color
        playerColor = color;

        // Assign to sprite renderer
        if (spriteRenderer == null)
            Debug.Log($"Failed to set color to {name} {nameof(PlayerController)}.");
        else
            spriteRenderer.color = color;
    }

    // Set up player input
    public void AssignPlayerInputDevice(PlayerInput playerInput)
    {
        // Record our player input (ie controller).
        PlayerInput = playerInput;
        // Find the references to the "Move" and "Jump" actions inside the player input's action map
        // Here I specify "Player/" but it in not required if assigning the action map in PlayerInput inspector.
        InputActionMove = playerInput.actions.FindAction($"Player/Move");
        InputActionJump = playerInput.actions.FindAction($"Player/Jump");
        InputActionInteract = playerInput.actions.FindAction($"Player/Interact");
    }

    // Assign player number on spawn
    public void AssignPlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;
    }

    // Runs each frame
    public void Update()
    {
        // Read the "Jump" action state, which is a boolean value
        if (InputActionJump.WasPressedThisFrame())
        {
            // Buffer input becuase I'm controlling the Rigidbody through FixedUpdate
            // and checking there we can miss inputs.
            HandleJump();
        }

        if (InputActionInteract.WasPressedThisFrame())
        {
            if (inInteractRange && interactTarget!= null)
            {
                interactTarget.TriggerSwitch();
            }
        }
    }

    // Runs each phsyics update
    void FixedUpdate()
    {
        if (rb2d == null)
        {
            Debug.Log($"{name}'s {nameof(PlayerController)}.{nameof(Rigidbody2D)} is null.");
            return;
        }

        CheckJump();

        // MOVE //NEED TO CHANGE THIS CODE
        // Read the "Move" action value, which is a 2D vector
        Vector2 moveValue = InputActionMove.ReadValue<Vector2>();

        rb2d.linearVelocity = new Vector2
        (
       moveValue.x * moveSpeed, rb2d.linearVelocity.y //Move x by input & y by pre-existing velocity
        );

        ApplyAdvancedJumpGravity();
    }

    // OnValidate runs after any change in the inspector for this script.
    private void OnValidate()
    {
        Reset();
    }

    // Reset runs when a script is created and when a script is reset from the inspector.
    private void Reset()
    {
        // Get if null
        if (rb2d == null)
            rb2d = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void HandleJump()
    {

        //If coyoteTime is still active, and the players hit the jump button
        if (coyoteTime > 0f )
        {
            //      pAudioSource.PlayOneShot(playerJump);
            //Add the jump value to the rigidbody2D velocity
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpHeight);

            //Set coyoteTime to 0 as soon as they jump so they can't jump again
            coyoteTime = 0f;
        }
        
    }

    void ApplyAdvancedJumpGravity()
    {
        Vector2 gravity = Physics2D.gravity * rb2d.gravityScale; //reference to gravity
        Vector2 gDir = gravity.normalized; // direction gravity pulls
        float aliG = Vector2.Dot(rb2d.linearVelocity, gDir); //the direction of the player compared to gravity
        float speedAliG = Mathf.Abs(aliG); //how fast the player is going with gravity

        if (speedAliG < dropStartSpeed) //speed the player up if they're hanging in air with low velocity
        {
            rb2d.linearVelocity += gravity * (fallMultiplier * 1.5f) * Time.fixedDeltaTime;
        }

        else if (aliG > 0f) //if moving with gravity
        {
            rb2d.linearVelocity += gravity * (fallMultiplier - 1f) * Time.fixedDeltaTime;
        }

        else if (aliG < 0f && !InputActionJump.IsPressed()) //moving against gravity & released jump
        {
            rb2d.linearVelocity += gravity * (lowJumpMultiplier - 1f) * Time.fixedDeltaTime;
        }

    }

    void CheckJump()
    {
        isGrounded = Physics2D.Raycast(
            feet.position,
            Vector2.down,
            groundCheckRay,
            groundLayer
        );

        if (isGrounded)
        {
            coyoteTime = coyoteTimeMax;
        }
        else
        {
            coyoteTime -= Time.fixedDeltaTime;
        }

        if (!dead)
        {
            //Set the animator parameter "isJumping"
            //      anim.SetBool("isJumping", !isGrounded);
        }
        else
        {
            //      anim.SetBool("isJumping", false);
        }
    }


    //Built-in function to draw debug elements such as lines, wire spheres and cubes
    private void OnDrawGizmos()
    {
        //This is to make the raycast visible, using the debug system
        if (isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.white;
        }
        //This is not actually associated with our Raycast, but uses the same math
        Gizmos.DrawRay(feet.position, Vector2.down * groundCheckRay);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            AreaInteract interact = collision.gameObject.GetComponent<AreaInteract>();
            if (interact!= null)
            {
                inInteractRange = true;
                interactTarget = interact;
            }
            
        }
           
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            Debug.Log("Left Interact Range");
            AreaInteract interact = collision.gameObject.GetComponent<AreaInteract>();
            if (interact != null && interact == interactTarget)
            {
                inInteractRange = false;
                interactTarget = null;
            }

        }
    }

}
