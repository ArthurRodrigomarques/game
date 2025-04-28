using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int life = 100;
    public bool death;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (death) return;

        MethodDeath();
    }

    // DEATH
    void MethodDeath()
    {
        if (life <= 0)
        {
            death = true;
            anim.SetTrigger("death"); 
        }
    }

    // HIT
    public void DamagePlayer(int quant)
    {
        if (death) return;

        life -= quant;

        if (life > 0)
        {
            anim.SetTrigger("damage");
        }

        GameManager.instance.UpdateLifeSlider(life); // Atualiza o slider depois de tomar dano
    }

}
