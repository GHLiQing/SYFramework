using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.FSM
{

	public enum StateID
	{
		idle,
		run,
		walk,

	}

	public abstract class FsmState 
	{
		#region �ֶ�
		protected FsmSystem fsmMananger;

		protected StateID stateID;
		
		#endregion

		#region ����
		public FsmState(FsmSystem fsmManager,StateID id)
		{
			this.fsmMananger = fsmManager;
		}

		/// <summary>
		/// ״̬�л�
		/// </summary>
		public abstract void Check();

		/// <summary>
		/// ������updata
		/// </summary>
		public abstract void Action();

		/// <summary>
		/// ����
		/// </summary>
		public virtual void OnEnter()
		{

		}

		/// <summary>
		/// �뿪
		/// </summary>
		public virtual void OnExit()
		{

		}
		#endregion


	}

	public class IdleState : FsmState
	{


		public IdleState(FsmSystem fsm,StateID stateID):base(fsm, stateID)
		{

		}

		public override void Action()
		{
			Debug.Log("Idle action");
		}

		public override void Check()
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				fsmMananger.ChangeState(StateID.walk);//�л�״̬
			}
		}

		public override void OnEnter()
		{
			Debug.Log("���� idle");
			
		}

		public override void OnExit()
		{
			Debug.Log("�뿪 idle");
		}
	}

	public class RunState : FsmState
	{

		public float runMoveSpeed = 10f;
		public RunState(FsmSystem fsm, StateID stateID) : base(fsm, stateID)
		{

		}

		public override void Action()
		{
			fsmMananger.Player.transform.Translate(Vector3.forward * runMoveSpeed * Time.deltaTime);
		}

		public override void Check()
		{
			if (Input.GetKeyDown(KeyCode.I))
			{
				fsmMananger.ChangeState(StateID.idle);
			}
		}

		public override void OnEnter()
		{
			Debug.Log("���� Run");
		}

		public override void OnExit()
		{
			Debug.Log("�뿪 Run");
		}
	}

	public class WalkState : FsmState
	{
		private float MoveSpeed = 3f;

		public WalkState(FsmSystem fsm, StateID stateID) : base(fsm, stateID)
		{

		}

		public override void Action()
		{
			fsmMananger.Player.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
		}

		public override void Check()
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				fsmMananger.ChangeState(StateID.run);//�л�״̬
			}
		}

		public override void OnEnter()
		{
			Debug.Log("���� Walk");
			//fsmMananger.P_animator.SetBool("Walk", true);
		}

		public override void OnExit()
		{
			Debug.Log("�뿪 walk");
		}
	}


}
