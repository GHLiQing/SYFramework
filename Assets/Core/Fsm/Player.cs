using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework;
public class Player : MonoBehaviour
{
	private FsmSystem fsmSystem;

	
	private void Awake()
	{
	
		fsmSystem = new FsmSystem(gameObject);

		FsmState idle = new IdleState(fsmSystem, StateID.idle);

		FsmState walk = new WalkState(fsmSystem, StateID.walk);

		FsmState run = new RunState(fsmSystem, StateID.run);

		fsmSystem.AddState( StateID.idle, idle);

		fsmSystem.AddState(StateID.walk, walk);

		fsmSystem.AddState(StateID.run, run);


		fsmSystem.StartFsmSystem(StateID.idle, idle);
	}


	private void Update()
	{
		fsmSystem.UpdateState();
	}

}
