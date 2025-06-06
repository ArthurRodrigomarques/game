using UnityEngine;

public class Player : MonoBehaviour
{

    // PLAYER
    public static Player _Player;

    // se o player pode andar
    public bool canMove = true;

    // velocidade 
    public float speed;
    public float JumpForce;

    // pulo e duplo pulo
    public bool isJumping;
    public bool doubleJump;

    // animações
    private Rigidbody2D rig;
    private Animator anim;

    // movimentação e pulo
    private PlayerMovement movement;
    private PlayerJump jump;
    private PlayerAnimation animationHandler;

    // dash
    private PlayerDash dash;

    // wall jump
    public LayerMask wallLayer;
    private PlayerWallJump wallJump;

    // VIDA
    private PlayerLife playerLife;

    void Start()
    {

        _Player = this;

        //Animator
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // movement and jump
        movement = new PlayerMovement(transform, anim, this, rig);
        jump = new PlayerJump(rig, anim, this);
        animationHandler = new PlayerAnimation(anim, transform);

        // dash
        dash = new PlayerDash(rig, transform, this, anim);

        // wall jump
        wallJump = new PlayerWallJump(rig, transform, this, anim, wallLayer);

        // vida
        playerLife = GetComponent<PlayerLife>(); 
    }

    void Update()
    {

        if (playerLife.death) return;
        if (!canMove) return;

        movement.Move();
        jump.Jump();
        dash.HandleDash();
        wallJump.HandleWallJump();

        // dar dano de teste se apertar a tecla H
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerLife.DamagePlayer(10); // tira 10 de vida
        }
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
