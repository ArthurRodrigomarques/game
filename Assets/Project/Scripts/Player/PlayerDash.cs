using UnityEngine;
using System.Collections;

public class PlayerDash
{
    private readonly Rigidbody2D rig;
    private readonly Transform playerTransform;
    private readonly Player player;
    private readonly Animator anim;

    private bool isDashing = false;

    private readonly float dashSpeed = 6f;
    private readonly float dashDuration = 0.2f;
    private readonly float dashCooldown = 1f;
    private float lastDashTime = -Mathf.Infinity;

    public PlayerDash(Rigidbody2D rig, Transform transform, Player player, Animator anim)
    {
        this.rig = rig;
        this.playerTransform = transform;
        this.player = player;
        this.anim = anim;
    }

    public void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= lastDashTime + dashCooldown && !isDashing)
        {
            player.StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        lastDashTime = Time.time;

        float originalGravity = rig.gravityScale;
        rig.gravityScale = 0;

        // Direção baseada na rotação do personagem
        float direction = playerTransform.eulerAngles.y == 180f ? -1f : 1f;

        rig.linearVelocity = new Vector2(direction * dashSpeed, 0f);
        anim.SetBool("dash", true);

        yield return new WaitForSeconds(dashDuration);

        rig.gravityScale = originalGravity;
        rig.linearVelocity = Vector2.zero;
        anim.SetBool("dash", false);

        isDashing = false;
    }
}
