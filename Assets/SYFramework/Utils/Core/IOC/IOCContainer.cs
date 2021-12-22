using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{
	/// <summary>
	/// ioc����
	/// </summary>
	public class IOCContainer
	{
		public static Dictionary<Type, object> modelAndInstanceDic = new Dictionary<Type, object>();

		/// <summary>
		/// ע��ʵ��
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="instance"></param>
		public static void Register<T>(T instance)
		{
			var type = typeof(T);
			if (!modelAndInstanceDic.ContainsKey(type))
			{
				modelAndInstanceDic.Add(type, instance) ;
			}
			else
			{
				Debug.LogError("�Ѿ�����ʵ��");
			}
		}

		/// <summary>
		/// ��� ʵ��
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T GetInstance<T>() where T:class
		{
			var type = typeof(T);
			object obj = null;
			if (modelAndInstanceDic.TryGetValue(type,out obj))
			{
				return obj as T;
			}
			return null;
		}

		/// <summary>
		/// �Ƴ�
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="instance"></param>
		public static void UnRegister<T>(T instance)
		{
			var type = typeof(T);
		
			if (modelAndInstanceDic.ContainsKey(type))
			{
				modelAndInstanceDic.Remove(type);
			}


		}
	}
	
}
