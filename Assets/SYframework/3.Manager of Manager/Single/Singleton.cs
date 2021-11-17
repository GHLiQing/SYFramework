using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.single
{
	/// <summary>
	/// 普通类单例
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class SingletonNomal<T> where T : SingletonNomal<T>
	{
		protected static T instance = null;
		
		protected SingletonNomal()
		{

		}

		public static  T GetSinleton
		{
			get
			{
				if (instance==null)
				{
					//通过反射获取子类对象
					//先获取所有非public 的构造方法
					// NonPublic 包含非 public 权限的方法
					// Instance 指定实例成员将包括在搜索中。
					//GetConstructors：返回为当前 Type 定义的所有公共构造函数。参数用于限制查找
					//用于子类继承时进行查找
					var ctors = typeof(T).GetConstructors(System.Reflection.BindingFlags.Instance
						| System.Reflection.BindingFlags.NonPublic);
					//从ctors中获取无参的构造方法
					var ctor = System.Array.Find(ctors, c => c.GetParameters().Length == 0);
					if (ctor==null)
					{
						Debug.Log("non-publc ctor() not found！");
					}
					//调用构造方法
					instance = ctor.Invoke(null) as T;
				}
				return instance ;
			}
		}
	}
}
