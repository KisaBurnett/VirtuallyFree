using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public bool isHit;

    public int enemyHP;
    public int enemyDamage;

    public Inventory inventory;

    public ItemData scraps;
    public ItemData fat;
    public ItemData drumstick;

    [SerializeField] int dropChanceMax;
    [SerializeField] int dropChanceMin;

    CombatScore plyrHp;
    GameObject hpTracker;

    private Collider2D enemyCollider;

    private int itemPick;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        isHit = false;
    }
    private void Start()
    {
        hpTracker = GameObject.FindWithTag("Score");
        plyrHp = hpTracker.GetComponent<CombatScore>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(plyrHp.playerHP > 0)
            {
                plyrHp.playerHP -= enemyDamage;
                Debug.Log(plyrHp.playerHP.ToString());
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

            PlayerStats.Instance.happiness -= 1;
            if(PlayerStats.Instance.happiness < 0)
            {
                PlayerStats.Instance.happiness = 0;
            }

            PlayerStats.Instance.enemiesKilled += 1;
            plyrHp.enemiesKilled += 1;

            if(PlayerStats.Instance.enemiesKilled >= PlayerStats.Instance.toLevel)
            {
                PlayerStats.Instance.level += 1;
            }

            if (dropChanceMax < 0)
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
                ItemInstance toAdd = new ItemInstance(drumstick);
                inventory.AddItem(toAdd);
            } else if((itemPick % 2) == 0)
            {
                ItemInstance toAdd = new ItemInstance(scraps);
                inventory.AddItem(toAdd);
            } else
            {
                ItemInstance toAdd = new ItemInstance(fat);
                inventory.AddItem(toAdd);
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
