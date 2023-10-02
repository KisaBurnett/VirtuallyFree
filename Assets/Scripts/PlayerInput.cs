using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    DiscreteMovement movement;
    [SerializeField] float speed = 1f;

    private void Awake()
    {
        movement = GetComponent<DiscreteMovement>();
    }


    void Update()
    {
        Vector3 vel = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.D))
        {
            vel.x = 1 * speed;
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            vel.x = -1 * speed;
        } else if (Input.GetKeyDown(KeyCode.W))
        {
            vel.y = 1 * speed;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            vel.y = -1 * speed;
        }

        movement.MoveTransform(vel);
    }
}
