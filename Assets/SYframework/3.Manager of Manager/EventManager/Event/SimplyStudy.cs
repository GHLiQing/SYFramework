using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
namespace QFramework.LQ
{
	public class SimplyStudy : MonoBehaviourSimplify
	{
		

		protected override void OnBeforOnDestroy()
		{
			
		}

		private void Awake()
		{
			//注册：
			Register(MsgID.sendMsg, Callback);
			Register("abc", Callback_1);

			Register("On", _=> { Debug.Log(_+"????"); });
		}

		//回调方法：
		private void Callback(object obj)
		{
			Debug.Log("回调:" + obj.ToString());
		}

		private void Callback_1(object obj)
		{
			Debug.Log("回调:" + obj.ToString());
		}

		
	
	}
}

