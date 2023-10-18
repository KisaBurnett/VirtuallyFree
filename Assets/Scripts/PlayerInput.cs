using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PhysicsMovement movement;

    private void Awake()
    {
        movement = GetComponent<PhysicsMovement>();
    }

    void FixedUpdate()
    {
        Vector3 vel = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            vel.x = 1;
        } if (Input.GetKey(KeyCode.A))
        {
            vel.x = -1;
        } if (Input.GetKey(KeyCode.W))
        {
            vel.y = 1;
        } if (Input.GetKey(KeyCode.S))
        {
            vel.y = -1;
        }

        movement.MoveCharacter(vel);
    }
}
