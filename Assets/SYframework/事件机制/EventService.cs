using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework.LQ.Evnet
{
	/// <summary>
	/// 事件服务对象
	/// 
	/// 多个服务对应一个基础服务静态类或者单例 享元模式
	/// </summary>
	public class EventService 
	{

		 List<System. Action> mUnRegisterList = new List<System.Action>();


		public void Send<T>(T t)
		{
			TypeEventSystem.Send<T>(t);
		}

		public void Register<T>(Action<T> onRecive)
		{
			TypeEventSystem.Register<T>(onRecive);
			//注销事件使用 集成在注册的时候 防止忘记注册
			mUnRegisterList.Add(()=> {

				TypeEventSystem.UnRegister<T>(onRecive);
			});
		}

		public void UnReigister<T>(Action<T> onRecive)
		{
			TypeEventSystem.UnRegister<T>(onRecive);
		}

		public void RegisterAll()
		{
			mUnRegisterList.ForEach(action=>action());
			mUnRegisterList.Clear();
		}


	}
}

