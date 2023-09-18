using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator animator;
    public int maxhealth = 100;
    int currenthealth;
    
    void Start()
    {
        currenthealth = maxhealth;
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;

        animator.SetTrigger("hurt");

        if (currenthealth <= 0)
        {
            Die();
        }
    }
   
    void Die()
    {
        animator.SetBool("isdead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
