using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAI : MonoBehaviour
{
    public PhysicsMovement movement;
    public Transform targetTransform;
    public EnemyStats enemyInfo;
    public float viewRadius;
    AIState currentState;

    GameObject targetObject;

    public AIStateWait waitState;
    public AIStatePatrol patrolState;
    public AIStateChase chaseState;

    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("Player");
        targetTransform = targetObject.transform;
        movement = GetComponent<PhysicsMovement>();
        enemyInfo = GetComponent<EnemyStats>();
        
        waitState = new AIStateWait(this);
        patrolState = new AIStatePatrol(this);
        chaseState = new AIStateChase(this);

        ChangeState(patrolState);
    }

    public void ChangeState(AIState newState)
    {
        currentState = newState;
        newState.BeginState();
    }

    void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdateStateBase();
        }
    }
    public bool CanSeeTarget()
    {
        if (Vector3.Distance(transform.position, targetTransform.position) <= viewRadius)
        {
            return true;
        }
        return false;
    }
}
