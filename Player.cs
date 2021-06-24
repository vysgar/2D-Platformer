using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Collider2D myCollider2D;
    float moveAxis;
    [SerializeField] float playerSpeed = 0f;
    [SerializeField] float jumpX = 0f;
    [SerializeField] float jumpY = 0f;
    Vector2 playerMovement;
    Animator m_animator;
    bool canDoubleJump = false;
    public Vector3 currentRotation;

    int JumpHash = Animator.StringToHash("Base Layer.Jumping");
    int DoubleJumpHash = Animator.StringToHash("Doublejumping");

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        FlipAndMove();
        ControlAnimation();
        PlayerJump();
        
    }

    public void FlipAndMove()
    {
        moveAxis = Input.GetAxisRaw("Horizontal");
        playerMovement = new Vector2(moveAxis * playerSpeed, rb.velocity.y);

        if (moveAxis == 1)
        {
            rb.velocity = playerMovement;
            //GetComponent<SpriteRenderer>().flipX = false;
            transform.eulerAngles = new Vector3(0, 0, 0);


        }
        else if (moveAxis == -1)
        {
            rb.velocity = playerMovement;
            transform.eulerAngles = currentRotation;
        }
        else
        {
            rb.velocity = playerMovement;
        }
    }

    public void ControlAnimation()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            m_animator.SetBool("Running", true);
        }
        else
        {
            m_animator.SetBool("Running", false);
        }

        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            m_animator.SetBool("Jumping", true);
            m_animator.SetBool("Running", false);
        }
        else
        {
            m_animator.SetBool("Jumping", false);
            m_animator.SetBool("Doublejumping", false);
        }

      
       

    }

    public void PlayerJump()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
            {
                rb.velocity = new Vector2(jumpX, jumpY);
                canDoubleJump = true;
            }
            else if(canDoubleJump)
            {
                DoubleJump();
                canDoubleJump = false;
                
            }
            
        }
        
    }

    public void DoubleJump()
    {
        
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                m_animator.SetBool("Doublejumping", true);
                rb.velocity = new Vector2(jumpX, jumpY);
                
            }
    }
          

    
}
