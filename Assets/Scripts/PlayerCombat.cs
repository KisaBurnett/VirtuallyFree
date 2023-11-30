// Credit to Blackthornprod on YouTube from their video:
// "HOW TO MAKE 2D MELEE COMBAT - EASY UNITY TUTORIAL"
// https://www.youtube.com/watch?v=1QfxdUpVh5I

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackRange;
    public float startCoolDown;
    
    public LayerMask enemies;

    public Transform attackPos;

    private float coolDownTime;

    private int damage;

    private SpriteRenderer sprite;

    private void Start()
    {
        if (PlayerStats.Instance.level <= 5)
        {
            damage = 2;
        }
        else if (PlayerStats.Instance.level <= 10)
        {
            damage = 5;
        }
        else if(PlayerStats.Instance.level > 10)
        {
            damage = 7;
        }

        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (coolDownTime <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                coolDownTime = startCoolDown;
                this.GetComponent<AudioSource>().Play();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(DamageBlink());
        }
    }

    IEnumerator DamageBlink()
    {
        for (int i = 0; i < 3; i++)
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.black;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
