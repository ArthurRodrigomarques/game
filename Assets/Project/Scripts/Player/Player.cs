using UnityEngine;

public class Player : MonoBehaviour
{
    // velocidade 
    public float speed;
    public float JumpForce;

    // pulo e duplo pulo
    public bool isJumping;
    public bool doubleJump;

    // anima��es
    private Rigidbody2D rig;
    private Animator anim;

    // movimenta��o e pulo
    private PlayerMovement movement;
    private PlayerJump jump;
    private PlayerAnimation animationHandler;

    // dash
    private PlayerDash dash;

    void Start()
    {
        //Animator
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // movement and jump
        movement = new PlayerMovement(transform, anim, this, rig);
        jump = new PlayerJump(rig, anim, this);
        animationHandler = new PlayerAnimation(anim, transform);

        //dash
        dash = new PlayerDash(rig, transform, this, anim);
    }

    void Update()
    {
        movement.Move();
        jump.Jump();
        dash.HandleDash();
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