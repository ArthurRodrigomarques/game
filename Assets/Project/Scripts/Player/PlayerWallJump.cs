using UnityEngine;
using System.Collections;

public class PlayerWallJump
{
    private Rigidbody2D rig;
    private Transform transform;
    private Player player;
    private Animator anim;

    private float wallSlideSpeed = 0.5f;
    private float wallJumpForceX = 8f;
    private float wallJumpForceY = 10f;
    private bool isTouchingWall;
    private bool isWallSliding;
    private bool wallJumping;
    private float wallJumpTime = 0.2f;
    private float wallJumpCounter;

    private LayerMask wallLayer;
    private float wallCheckDistance = 0.5f;

    public PlayerWallJump(Rigidbody2D rig, Transform transform, Player player, Animator anim, LayerMask wallLayer)
    {
        this.rig = rig;
        this.transform = transform;
        this.player = player;
        this.anim = anim;
        this.wallLayer = wallLayer;
    }

    public void HandleWallJump()
    {
        WallSlide();

        if (Input.GetButtonDown("Jump") && isWallSliding)
        {
            wallJumping = true;
            wallJumpCounter = wallJumpTime;

            Vector2 direction = transform.eulerAngles.y == 0 ? Vector2.left : Vector2.right;
            rig.linearVelocity = new Vector2(direction.x * wallJumpForceX, wallJumpForceY);
        }

        if (wallJumping)
        {
            wallJumpCounter -= Time.deltaTime;

            if (wallJumpCounter <= 0)
            {
                wallJumping = false;
            }
        }
    }

    private void WallSlide()
    {
        if (wallJumping)
        {
            // Não desliza enquanto está no impulso do pulo da parede
            anim.SetBool("wallSlide", false);
            return;
        }

        bool wallRight = Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance, wallLayer);
        bool wallLeft = Physics2D.Raycast(transform.position, Vector2.left, wallCheckDistance, wallLayer);
        isTouchingWall = wallRight || wallLeft;

        if (isTouchingWall && player.isJumping && rig.linearVelocity.y < 0)
        {
            isWallSliding = true;
            rig.linearVelocity = new Vector2(rig.linearVelocity.x, -wallSlideSpeed);
            anim.SetBool("wallSlide", true);
        }
        else
        {
            isWallSliding = false;
            anim.SetBool("wallSlide", false);
        }
    }
}
