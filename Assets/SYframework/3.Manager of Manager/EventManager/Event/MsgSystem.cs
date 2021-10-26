using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework.LQ
{
	/// <summary>
	/// 消息机制 基于字符串类型
	/// </summary>
	public class MsgSystem 
	{
		private static Dictionary<string, Action<object>> mMsgDic = new Dictionary<string, Action<object>>();

		public static void Send(string type,object obj)
		{
			if (mMsgDic.ContainsKey(type))
			{
				mMsgDic[type](obj);
			}
		}

		public static void Register(string type,Action<object> onRecive)
		{
			if (mMsgDic.ContainsKey(type))
			{
				mMsgDic[type] += onRecive;
			}
			else
			{
				mMsgDic.Add(type, onRecive);
			}
		}
		public static void UnRegister(string type,Action<object> onRecive=null)
		{
			mMsgDic.Remove(type);

		}
	}

}
