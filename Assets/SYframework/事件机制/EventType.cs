using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 基于类型的事件系统
/// 
/// 模块于模块之间通信： 直接调用这个就可以了
/// 模块内部消息机制,直接创建服务对象 用于模块自己使用
/// </summary>
namespace QFramework.LQ.Evnet
{

	//定义注册事件的 接口
	

	//注册接口 只负责存储在字典中
	interface IRegistertions
	{

	}
	/// <summary>
	/// 多个注册
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Resgistertion<T> : IRegistertions
	{
		/// <summary>
		/// 委托本身就是多个注册
		/// </summary>
		public Action<T> action = obj => { };
	}
	public class TypeEventSystem
	{

		/// <summary>
		/// 定义字典 用于存储数据 一对多的形式
		/// </summary>
		private static Dictionary<Type, IRegistertions> mTypeEventDict = new Dictionary<Type, IRegistertions>();

	
		/// <summary>
		/// 注册事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="action"></param>
		public static void Register<T>(System.Action<T> action)
		{
			var type = typeof(T);
			IRegistertions registertions = null;
			//如果存在
			if (mTypeEventDict.TryGetValue(type,out registertions))
			{
				var vr = registertions as Resgistertion<T>;
				vr.action += action;
			}
			else  //从没注册过该类型  需要创建一个该类型的注册对象
			{
				var vr = new Resgistertion<T>();
				vr.action += action;
				mTypeEventDict.Add(type, vr);

			}
		}
		/// <summary>
		/// 取消注册事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public static void UnRegister<T>(System.Action<T> action)
		{
			var type = typeof(T);
			IRegistertions registertions = null;
			if (mTypeEventDict.TryGetValue(type,out registertions))
			{
				var vr = registertions as Resgistertion<T>;
				vr.action -= action;
			}
		}

		/// <summary>
		/// 发送事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t"></param>
		public static void Send<T>(T t)
		{
			var type = typeof(T);
			IRegistertions registertions = null;
			if (mTypeEventDict.TryGetValue(type,out registertions))
			{
				var res = registertions as Resgistertion<T>;
				res.action(t);
			}
		}

	}



}

