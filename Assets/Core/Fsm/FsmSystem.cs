using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class FsmSystem
	{

		#region �ֶ�
		private FsmState currentstate;

		public StateID currentstateID;
		public Dictionary<StateID, FsmState> mstate_Dic = new Dictionary<StateID, FsmState>();

		//todo
		//����������붯�������� ������ҵ�һЩ��Ϣ

		private Animator PlayerAnimator;

		private GameObject player;
		#endregion

		#region ����
		public Animator P_animator { get => PlayerAnimator; set => PlayerAnimator = value; }
		public GameObject Player { get => player; set => player = value; }
		public FsmState Currentstate { get => currentstate; set => currentstate = value; }

		#endregion

		/// <summary>
		/// ״̬����ʼ��һЩ����
		/// </summary>
		/// <param name="player"></param>
		/// <param name="animator"></param>
		public FsmSystem(GameObject player=null,Animator animator=null)
		{
			this.PlayerAnimator = animator;
			this.player = player;

			Debug.Log("״̬����ʼ�� ����");
		}

		/// <summary>
		/// ����״̬��
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
		/// ��ǰ״ִ̬��
		/// </summary>
		public void UpdateState()
		{
			Currentstate.Action();

			Currentstate.Check();
		}
		
		/// <summary>
		/// ����״̬
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
		/// ״̬������ת��
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
		/// �Ƴ�״̬�������״̬ 
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
