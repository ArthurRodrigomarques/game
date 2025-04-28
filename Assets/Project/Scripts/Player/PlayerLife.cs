using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    public int life = 100;
    public bool death;
    private Animator anim;
    private Rigidbody2D rig;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (death) return;
        MethodDeath();
    }

    void MethodDeath()
    {
        if (life <= 0)
        {
            death = true;
            anim.SetTrigger("death");
            Player._Player.canMove = false;
        }
    }

    public void DamagePlayer(int quant)
    {
        if (death) return;

        life -= quant;
        if (life > 0)
        {
            anim.SetTrigger("damage");
            StartCoroutine(ApplyStun());
        }

        GameManager.instance.UpdateLifeSlider(life);
    }

    IEnumerator ApplyStun()
    {
        Player._Player.canMove = false;
        yield return new WaitForSeconds(0.3f); // stun de 0.3 segundos
        Player._Player.canMove = true;
    }
}
