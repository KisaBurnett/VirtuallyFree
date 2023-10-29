// Credit to Blackthornprod on YouTube from their video:
// "HOW TO MAKE 2D MELEE COMBAT - EASY UNITY TUTORIAL"
// https://www.youtube.com/watch?v=1QfxdUpVh5I

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float coolDownTime;
    public float startCoolDown;

    public Transform attackPos;
    public float attackRange;
    public LayerMask enemies;
    public int damage;

    private void Update()
    {
        if (coolDownTime <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                coolDownTime = startCoolDown;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    if(enemiesToDamage[i].GetComponent<EnemyStats>().enemyHP > 0)
                    {
                        enemiesToDamage[i].GetComponent<EnemyStats>().EnemyTakeDamage(damage);
                    }
                }
            }
        } else
        {
            coolDownTime -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
