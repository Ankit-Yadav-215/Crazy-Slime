using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform Attackpnt;
    public float attackrange = 0.5f;
    public LayerMask enemylayers;
    public int attackdamage = 40;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Attack();
        }
    }


    void Attack ()
    {
        animator.SetTrigger("isattack");
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(Attackpnt.position, attackrange, enemylayers);

        foreach(Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<enemy>().TakeDamage(attackdamage);
        }

    }

     void OnDrawGizmosSelected()
    {
        if (Attackpnt == null)
            return;

        Gizmos.DrawSphere(Attackpnt.position, attackrange);
    }
}
