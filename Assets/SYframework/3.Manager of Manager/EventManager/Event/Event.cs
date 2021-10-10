using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{
	/// <summary>
	/// 简单 
	/// 消息基类
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Event<T> where T :Event<T> 
	{
		private static Action callback = null;


		public static void Regisgter(Action funtiion)
		{
			callback += funtiion;
		}

		public static void UnRegister(Action funtiion)
		{
			callback -= funtiion;
		}


		public static void Send()
		{
			callback?.Invoke();
		}

	}
}

