using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    // Adds a clamped value to the current transform.
    // Clamping ensures player character stays in play space.
    public void MoveTransform(Vector3 pos)
    {
        Vector3 currentPosVals = transform.position;

        currentPosVals.x = Mathf.Clamp(transform.position.x + pos.x, -8f, 8f);
        currentPosVals.y = Mathf.Clamp(transform.position.y + pos.y, -4.5f, 4.5f);

        transform.position = currentPosVals;
    }
}
