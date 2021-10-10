using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LQFramework
{
	public class FsmController
	{

		public delegate void FSMTranslationCallfunc();
		
		/// <summary>
		/// 状态类
		/// </summary>
		public class FSMState
		{
			public string name;
			public FSMState(string name)
			{
				this.name = name;
			}
			/// <summary>
			/// 存储事件对应的条转
			/// </summary>
			public Dictionary<string, FsmTranslation> TranslationDict = new Dictionary<string, FsmTranslation>();

		}

		/// <summary>
		/// 跳转类
		/// </summary>
		public class FsmTranslation
		{
			public FSMState fromState;
			public string name;
			public FSMState toState;
			public FSMTranslationCallfunc callfunc;
			public FsmTranslation(FSMState fromstate,string name,FSMState toState,FSMTranslationCallfunc callfunc)
			{
				this.fromState = fromstate;
				this.name = name;
				this.toState = toState;
				this.callfunc = callfunc;
			}

		
		}

		private FSMState mCurState;

		public FSMState Curstate
		{
			get
			{
				return mCurState;
			}
		}

		Dictionary<string, FSMState> StateDict = new Dictionary<string, FSMState>();

		/// <summary>
		///添加状态
		/// </summary>
		/// <param name="state"></param>
		public void AddState(FSMState state)
		{
			StateDict[state.name] = state;
		}

		/// <summary>
		/// 添加跳转
		/// </summary>
		/// <param name="translation"></param>
		public void AddTranslation(FsmTranslation translation)
		{
			StateDict[translation.fromState.name].TranslationDict[translation.name] = translation;
		}

		//启动状态机
		 public void Start(FSMState state)
		{
			mCurState = state;
		}

		/// <summary>
		/// 处理事件
		/// </summary>
		/// <param name="name"></param>
		public void HandleEvent(string name)
		{
			if (mCurState!=null&&mCurState.TranslationDict.ContainsKey(name))
			{
				mCurState.TranslationDict[name].callfunc();
				mCurState = mCurState.TranslationDict[name].toState;
			}
		}

	}

}
