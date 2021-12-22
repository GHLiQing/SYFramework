using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class ObserverModel
	{
	}

	/// <summary>
	/// 通知消息
	/// </summary>
	public class NotifyEvent
	{

	}
	/// <summary>
	/// 观察者
	/// </summary>
	public class Observer
	{
		public Observer()
		{
			OnRegister();
		}

		private void OnRegister()
		{
			TypeEventSystem.Register<NotifyEvent>(Update);
		}


		private void Update(NotifyEvent notifyEvent)
		{
			Debug.Log("UpdataEvent  notifyEvent");
		}
		public void OnUnRegister()
		{
			TypeEventSystem.UnRegister<NotifyEvent>(Update);
		}


	}

	/// <summary>
	/// 主题
	/// </summary>
	public class Subject
	{
		/// <summary>
		/// 发送感兴趣的事情
		/// </summary>
		public void InsterentThing()
		{
			OnSendEevent();
		}

		private void OnSendEevent()
		{
			TypeEventSystem.Send(new NotifyEvent());
		}
	}

}


