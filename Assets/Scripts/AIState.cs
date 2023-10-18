using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState
{
	protected StateAI ai;
	protected float stateTimer = 0;
	public AIState(StateAI newAI)
	{
		ai = newAI;
		stateTimer = 0;
	}
	public void UpdateStateBase()
	{
		stateTimer += Time.fixedDeltaTime;
		UpdateState();
	}

	public abstract void UpdateState();
	public abstract void BeginState();
}
