using UnityEngine;

public class PlayerMovement
{
    private Transform transform;
    private Animator anim;
    private Player player;
    private Rigidbody2D rig;

    private LayerMask groundLayer = 1 << 8;
    private float wallCheckDistance = 0.1f;

    public PlayerMovement(Transform transform, Animator anim, Player player, Rigidbody2D rig)
    {
        this.transform = transform;
        this.anim = anim;
        this.player = player;
        this.rig = rig;
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (!IsHittingWall(horizontal))
        {
            Vector3 movement = new Vector3(horizontal, 0f, 0f);
            transform.position += movement * Time.deltaTime * player.speed;
        }
        else
        {
            horizontal = 0f;
        }

        if (horizontal > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (horizontal < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    private bool IsHittingWall(float direction)
    {
        if (direction == 0f) return false;

        Vector2 origin = transform.position;
        Vector2 dir = direction > 0f ? Vector2.right : Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(origin, dir, wallCheckDistance, groundLayer);
        return hit.collider != null;
    }
}