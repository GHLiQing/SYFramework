using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework.Example
{


	public interface ITypeEventSystem 
	{
		/// <summary>
		/// 发送消息
		/// </summary>
		/// <typeparam name="T"></typeparam>
		void Send<T>() where T : new();
		void Send<T>(T t);

		/// <summary>
		/// 注册消息
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="onEvent"></param>
		/// <returns></returns>
		IUnRegister Register<T>(Action<T> onEvent);

		/// <summary>
		/// 注销消息
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="onEvent"></param>
		void UnRegister<T>(Action<T> onEvent);

	}

	/// <summary>
	/// 注销接口
	/// </summary>
	public interface IUnRegister
	{
		void UnRegister();
	}
	/// <summary>
	/// 注销实现
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class TypeEventSystemUnRegister<T> : IUnRegister
	{
		public ITypeEventSystem typeEventSystem { get; set; }

		public Action<T> OnEvent { get; set; } 

		public void UnRegister()
		{
			typeEventSystem.UnRegister(OnEvent);
			typeEventSystem = null;
			OnEvent = null;
		}
	}

	/// <summary>
	/// 注销触发器
	/// </summary>
	public class UnRegisterOnDestroyTrigger: MonoBehaviour
	{
		public List<IUnRegister> registerList = new List<IUnRegister>();
		public void AddRegier(IUnRegister unRegister)
		{
			registerList.Add(unRegister);
		}

		private void OnDestroy()
		{
			foreach (var item in registerList)
			{
				item.UnRegister();
			}
			registerList.Clear();
		}


	}
	/// <summary>
	/// 触发器扩展
	/// </summary>
	public static class UnRegisterOnDestroyTriggerExtsion
	{
		public static void UnRegisterOnDestroy(this IUnRegister self,GameObject gameObject)
		{
			var trigger = gameObject.GetComponent<UnRegisterOnDestroyTrigger>();
			if (!trigger)
			{
				trigger = gameObject.AddComponent<UnRegisterOnDestroyTrigger>();
			}
			trigger.AddRegier(self);
		}

	}

	/// <summary>
	/// 事件系统
	/// </summary>
	public class TypeEventSystem : ITypeEventSystem
	{
		interface IRegistesion
		{

		}
		class  Registerion<T> : IRegistesion
		{
			public Action<T> OnEvent = (v) => { };
		}


		private Dictionary<Type, IRegistesion> EventDic = new Dictionary<Type, IRegistesion>();
		public void Send<T>() where T : new()
		{
			var t = new T();
			Send<T>(t);
		}

		public void Send<T>(T t)
		{
			var type = typeof(T);
			IRegistesion registesion = null;
			if (EventDic.TryGetValue(type, out registesion))
			{
				var reg = registesion as Registerion<T>;
				reg.OnEvent?.Invoke(t);
			}
		}

		public void UnRegister<T>(Action<T> onEvent)
		{
			var type = typeof(T);
			IRegistesion registesion = null;
			if (EventDic.TryGetValue(type,out registesion))
			{
				var reg = registesion as Registerion<T>;
				reg.OnEvent -= onEvent;
			}
		}

		public IUnRegister Register<T>(Action<T> onEvent)
		{
			var type = typeof(T);
			IRegistesion registesion = null;
			if (EventDic.TryGetValue(type,out registesion))
			{
				var reg = registesion as Registerion<T>;
				reg.OnEvent += onEvent;
				
			}
			else
			{
				var reg=registesion as Registerion<T>;
				reg.OnEvent += onEvent;
				EventDic.Add(type, reg);
			}
			return new TypeEventSystemUnRegister<T>()
			{
				typeEventSystem = this,
				OnEvent = onEvent
			};
		}
	}
}
