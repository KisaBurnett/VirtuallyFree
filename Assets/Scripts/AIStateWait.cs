using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateWait : AIState
{
	public AIStateWait(StateAI newAI) : base(newAI)
	{
	}
	public override void UpdateState()
	{
		if (ai.CanSeeTarget())
		{
			ai.ChangeState(ai.chaseState);
		}
		ai.movement.Stop();
	}
	public override void BeginState()
	{

	}
}
