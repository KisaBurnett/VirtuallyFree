using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHP;
    public int enemyDamage;
    public bool isHit;
    SpriteRenderer sprite;
    private Collider2D enemyCollider;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        isHit = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(PlayerStats.Instance.playerHP > 0)
            {
                PlayerStats.Instance.playerHP -= enemyDamage;
                Debug.Log(PlayerStats.Instance.playerHP.ToString());
            }
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        enemyHP -= damage;
        StartCoroutine(DamageBlink());
        
        if(enemyHP <= 0)
        {
            Destroy(gameObject, .5f);
        }
    }

    IEnumerator DamageBlink()
    {
        isHit = true;
        enemyCollider.enabled = !enemyCollider.enabled;
        for (int i = 0; i < 3; i++)
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.black;
            yield return new WaitForSeconds(0.1f);
        }
        isHit = false;
        enemyCollider.enabled = !enemyCollider.enabled;
    }
}
