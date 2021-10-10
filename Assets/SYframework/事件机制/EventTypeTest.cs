using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QFramework.LQ.Evnet
{

	public class Tclass<T>
	{
		public void Test(T t)
		{

		}
	}

	public class EventTypeTest : MonoBehaviour
	{
		
		public class BaseEvent
		{

			public readonly object obj;
			public BaseEvent(object obj)
			{
				this.obj = obj;
			}
		}

		public class A: BaseEvent
		{
			public A(object obj) : base(obj)
			{

			}
		}

		public class B
		{

		}

		private void Awake()
		{

			Tclass<int> tclas = new Tclass<int>();
			tclas.Test(3);

			//1 直接调用
			//TypeEventSystem.Register<A>(Atest);
			//2 封装好的api
			this.Register<A>(Atest);

			Debug.Log(typeof(A));
			TypeEventSystem.Register<B>(Btest);

		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				//TypeEventSystem.Send(new A("你知道吗"));
				this.Send<A>(new A("封装好的api"));
			}
		}
		/// <summary>
		/// 注册事件回调
		/// </summary>
		/// <param name="a"></param>
		public void Atest(A a)
		{
			Debug.Log("a 的回调:"+a.obj);
		}


		public void Btest(B b)
		{
			Debug.Log("B 的回调");
		}

		private void OnDestroy()
		{
			//1
			//TypeEventSystem.UnRegister<A>(Atest);
			//2
			this.UnRegister<A>(Atest);

			//注销所有
			this.UnRegisterAll();

		}

		/// <summary>
		/// 封装成api
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="callback"></param>
		private void Send<T>(T eventkey)
		{
			TypeEventSystem.Send(eventkey);
		}

		private void Register<T>(Action<T> callback)
		{
			TypeEventSystem.Register<T>(callback);

			//注销绑定
			mUnRegisterAllList.Add(()=> {
				TypeEventSystem.UnRegister<T>(callback);
			});
		}
		private void UnRegister<T>(Action<T> callback)
		{
			TypeEventSystem.UnRegister<T>(callback);

		}

		private List<System. Action> mUnRegisterAllList = new List<System.Action>();
		/// <summary>
		/// 注销全部
		/// </summary>
		private void UnRegisterAll()
		{
			mUnRegisterAllList.ForEach(a => a());
			mUnRegisterAllList.Clear();
		}
	}

	
}

