using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHP;
    private int enemyDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(PlayerStats.Instance.playerHP > 0)
            {
                PlayerStats.Instance.playerHP -= enemyDamage;
            }
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        enemyHP -= damage;
        
        if(enemyHP <= 0)
        {
            Destroy(gameObject, .5f);
        }
    }
}
