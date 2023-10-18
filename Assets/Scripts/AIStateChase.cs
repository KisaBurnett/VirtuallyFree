using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateChase : AIState
{
	public AIStateChase(StateAI newAI) : base(newAI)
	{

	}

	public override void UpdateState()
	{
		if (ai.CanSeeTarget())
		{
			ai.movement.MoveToward(ai.targetTransform.position);
		}
		else
		{
			ai.movement.Stop();
			ai.ChangeState(ai.patrolState);
		}
	}

	public override void BeginState()
	{
		//INDICATE ATTACK!
	}
}
