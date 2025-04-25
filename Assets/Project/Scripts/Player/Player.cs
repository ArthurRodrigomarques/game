//using UnityEngine;

//public class Player : MonoBehaviour
//{
//    // walking speed
//    public float speed;
//    // jump
//    public float JumpForce;
//    public bool isJumping;
//    public bool doubleJump;

//    private Rigidbody2D rig;

//    // animation 
//    private Animator anim;

//    void Start()
//    {
//        rig = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//    }

//    void Update()
//    {
//        Move();
//        Jump();
//    }

//    // Move
//    void Move()
//    {
//        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
//        transform.position += movement * Time.deltaTime * speed;

//        // conditions to move forward and backward
//        if (Input.GetAxis("Horizontal") > 0f)
//        {
//            anim.SetBool("walk", true);
//            transform.eulerAngles = new Vector3(0f, 0f, 0f);
//        }
//        if (Input.GetAxis("Horizontal") < 0f)
//        {
//            anim.SetBool("walk", true);
//            transform.eulerAngles = new Vector3(0f, 180f, 0f);
//        }
//        if (Input.GetAxis("Horizontal") == 0f)
//        {
//            anim.SetBool("walk", false);
//        }

//    }


//    // Jump
//    void Jump()
//    {
//        if (Input.GetButtonDown("Jump"))
//        {
//            if (!isJumping)
//            {
//                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
//                doubleJump = true;
//                anim.SetBool("jump", true);
//            }
//            else
//            {
//                if (doubleJump)
//                {
//                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
//                    doubleJump = false;
//                }
//            }

//        }
//    }

//    // ground collision
//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.layer == 8)
//        {
//            isJumping = false;
//            anim.SetBool("jump", false);
//        }
//    }

//    void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.layer == 8)
//        {
//            isJumping = true;
//        }
//    }
//}

using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    private PlayerMovement movement;
    private PlayerJump jump;
    private PlayerAnimation animationHandler;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        movement = new PlayerMovement(transform, anim, this, rig);
        jump = new PlayerJump(rig, anim, this);
        animationHandler = new PlayerAnimation(anim, transform);
    }

    void Update()
    {
        movement.Move();
        jump.Jump();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}