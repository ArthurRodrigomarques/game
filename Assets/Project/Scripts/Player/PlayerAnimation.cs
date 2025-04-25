using UnityEngine;

public class PlayerAnimation
{
    private Animator anim;
    private Transform transform;

    public PlayerAnimation(Animator anim, Transform transform)
    {
        this.anim = anim;
        this.transform = transform;
    }

    public void SetWalk(bool state)
    {
        anim.SetBool("walk", state);
    }

    public void SetJump(bool state)
    {
        anim.SetBool("jump", state);
    }

    public void FaceDirection(float horizontal)
    {
        if (horizontal > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (horizontal < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }
}