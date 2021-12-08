using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{
	/// <summary>
	/// 服务对象类 -0145
	/// </summary>
	public class EventService
	{
		private List<Action> mUnRegisterList = new List<Action>();

		/// <summary>
		/// 发送事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="eventkey"></param>
		public void Send<T>(T eventkey)
		{
			TypeEventSystem.Send<T>(eventkey);
		}

		/// <summary>
		/// 注册事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="onRecive"></param>
		public void Register<T>(Action<T> onRecive)
		{
			TypeEventSystem.Register<T>(onRecive);

			mUnRegisterList.Add(() => {

				TypeEventSystem.UnRegister<T>(onRecive);
			});
		}

		/// <summary>
		/// 单独取消一个事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="onReceive"></param>
		public void UnRegister<T>(Action<T> onReceive)
		{
			TypeEventSystem.UnRegister<T>(onReceive);
		}

		/// <summary>
		/// 全部注销
		/// </summary>
		public void UnAllRegister()
		{
			mUnRegisterList.ForEach(eventKey =>
			{
				eventKey();
			});
			mUnRegisterList = null;
		}

	}

}
