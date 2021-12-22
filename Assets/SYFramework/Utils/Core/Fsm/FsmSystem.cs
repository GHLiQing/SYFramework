using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class FsmSystem
	{

		#region 字段
		private FsmState currentstate;

		public StateID currentstateID;
		public Dictionary<StateID, FsmState> mstate_Dic = new Dictionary<StateID, FsmState>();

		//todo
		//这里可以引入动画控制器 或者玩家的一些信息

		private Animator PlayerAnimator;

		private GameObject player;
		#endregion

		#region 属性
		public Animator P_animator { get => PlayerAnimator; set => PlayerAnimator = value; }
		public GameObject Player { get => player; set => player = value; }
		public FsmState Currentstate { get => currentstate; set => currentstate = value; }

		#endregion

		/// <summary>
		/// 状态机初始化一些数据
		/// </summary>
		/// <param name="player"></param>
		/// <param name="animator"></param>
		public FsmSystem(GameObject player=null,Animator animator=null)
		{
			this.PlayerAnimator = animator;
			this.player = player;

			Debug.Log("状态机初始化 开启");
		}

		/// <summary>
		/// 开启状态机
		/// </summary>
		/// <param name="id"></param>
		/// <param name="fsmState"></param>
		public void StartFsmSystem(StateID id,FsmState fsmState)
		{
			currentstateID = id;
			currentstate = fsmState;
			currentstate.OnEnter();
		}
		/// <summary>
		/// 当前状态执行
		/// </summary>
		public void UpdateState()
		{
			Currentstate.Action();

			Currentstate.Check();
		}
		
		/// <summary>
		/// 加入状态
		/// </summary>
		/// <param name="id"></param>
		/// <param name="fsmState"></param>
		public void AddState(StateID id,FsmState fsmState)
		{
			if (!mstate_Dic.ContainsKey(id))
			{
				mstate_Dic.Add(id, fsmState);
			}
			else
			{
				return;
			}
		}

		/// <summary>
		/// 状态机控制转变
		/// </summary>
		/// <param name="stateID"></param>
		public void ChangeState(StateID stateID)
		{
			if (Currentstate == null) return;
			if (mstate_Dic.ContainsKey(stateID))
			{
				Currentstate.OnExit();
				currentstateID = stateID;
				Currentstate = mstate_Dic[currentstateID];
				Currentstate.OnEnter();
			}
		}

		/// <summary>
		/// 移除状态机里面的状态 
		/// </summary>
		/// <param name="stateID"></param>
		public void RemoveState(StateID stateID)
		{
			if (mstate_Dic.ContainsKey(stateID))
			{
				mstate_Dic.Remove(stateID);
			}
			else
			{
				return;
			}
		}

	}

}
