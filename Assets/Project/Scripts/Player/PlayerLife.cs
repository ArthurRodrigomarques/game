using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    public int life = 100;
    public bool death;
    private Animator anim;
    private Rigidbody2D rig;

    public Vector3 initialPosition;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
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
            StartCoroutine(DeathSequence()); 
        }
    }

    // espera para dar a tela de morte
    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.ShowGameOver();
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
