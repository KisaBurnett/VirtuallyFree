using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] protected float charSpeed = 1f;
    protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter(Vector3 velocity)
    {
        rb.velocity = velocity * charSpeed;
        if(velocity.x > 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
        } else if (velocity.x <= 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
    }

    public void MoveToward(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction = Vector3.Normalize(direction);
        MoveCharacter(direction);
    }

    public void Stop()
    {
        MoveCharacter(Vector3.zero);
    }
}
