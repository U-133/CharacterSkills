using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private float dirX;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;
    private enum movementState { idle, running, jumping, falling }
    
    
    private ShieldController shieldController;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        shieldController = GetComponent<ShieldController>();
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");

        rigidBody.velocity = new Vector2(dirX * moveSpeed, rigidBody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
          
        }

        if (Input.GetKeyDown(KeyCode.Z)){
            shieldController.ActivateShield();
        }

        UpdateAnimationState();
        
    }

    private void UpdateAnimationState()
    {

        movementState state;

        if(dirX > 0f)
        {
            state = movementState.running;
            sprite.flipX = false;
            
        }

        else if (dirX < 0f)
        {
            state = movementState.running;
            sprite.flipX = true;
        }

        else
        {
            state = movementState.idle;
        }

        if (rigidBody.velocity.y > .1f)
        {
            state = movementState.jumping;
        }
        else if (rigidBody.velocity.y < -.1f)
        {
            state = movementState.falling;
        }

        

        animator.SetInteger("state", (int)state);
    }

   


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.size, 0f, Vector2.down, .1f, jumpableGround);
        
    }

    
   
}
