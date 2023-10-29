using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHP;
    public int enemyDamage;
    public Inventory inventory;
    public bool isHit;
    public ItemInstance scraps;
    public ItemInstance fat;
    public ItemInstance drumstick;

    [SerializeField] int dropChanceMax;
    [SerializeField] int dropChanceMin;
    private SpriteRenderer sprite;
    private Collider2D enemyCollider;
    private int itemPick;

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
            // Drop item
            if(dropChanceMax < 0)
            {
                dropChanceMax = 5;
            }
            if (dropChanceMin < 0)
            {
                dropChanceMin = 1;
            }

            itemPick = Random.Range(dropChanceMin, dropChanceMax);

            if(itemPick == 0)
            {
                inventory.AddItem(drumstick);
                Debug.Log("Jackpot!");
            } else if((itemPick % 2) == 0)
            {
                inventory.AddItem(scraps);
                Debug.Log("It's even!");
            } else
            {
                inventory.AddItem(fat);
                Debug.Log("It's odd!");
            }
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
