using UnityEngine;

public class PlayerJump
{
    private Rigidbody2D rig;
    private Animator anim;
    private Player player;

    public PlayerJump(Rigidbody2D rig, Animator anim, Player player)
    {
        this.rig = rig;
        this.anim = anim;
        this.player = player;
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!player.isJumping)
            {
                rig.AddForce(new Vector2(0f, player.JumpForce), ForceMode2D.Impulse);
                player.doubleJump = true;
                anim.SetBool("jump", true);
            }
            else if (player.doubleJump)
            {
                rig.AddForce(new Vector2(0f, player.JumpForce), ForceMode2D.Impulse);
                player.doubleJump = false;
            }
        }
    }
}