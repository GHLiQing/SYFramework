using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{
	/// <summary>
	/// ��ͨ����
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class Single<T> where T : Single<T>
	{
		protected static T mInstance = null;

		protected Single(){ }

	
		public static T Instance
		{
			get
			{
				if (mInstance == null)
				{
					var cons = typeof(T).GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
				 	var con= Array.Find(cons, c => c.GetParameters().Length == 0);
					if (con==null)
					{
						throw new Exception("û���ҵ�����" + typeof(T).Name);
					}
					mInstance = con.Invoke(null) as T;
				}
				return mInstance;
			}
		}
	}


	/// <summary>
	/// �̳�mono
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class MonoSingleton<T> :MonoBehaviour where T : MonoSingleton<T>
	{
		protected static T mInstance = null;

		public static T Instance
		{
			get
			{
				mInstance=FindObjectOfType<T>();
				if (FindObjectsOfType<T>().Length>0)
				{
					Debug.Log("�Ѿ����ڵ���"+typeof(T).Name);
					return mInstance;
				}
				if (mInstance==null)
				{
					var instanceName = typeof(T).Name;
					var obj= GameObject.Find(instanceName);
					if (obj==null)
						obj = new GameObject(instanceName);
					mInstance = obj.AddComponent<T>();
					DontDestroyOnLoad(mInstance);
					Debug.Log("������ǰ������" + typeof(T).Name);
				}
				else
				{
					Debug.LogError("�Ѵ��ڵ�ǰ������"+ typeof(T).Name);
				}
				return mInstance;
			}
		}

		protected virtual  void OnDestroy()
		{
			mInstance = null;
		}
	}

}
