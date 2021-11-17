using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.single
{
	public class MonoSingleton<T> :MonoBehaviour where T:MonoSingleton<T>
	{
		protected static T mInstance = null;
		public static T Instance
		{
			get
			{
				//首先查找是否拥有该类型的单例
				if (mInstance==null)
				{
					mInstance = FindObjectOfType<T>();
					if (FindObjectsOfType<T>().Length>1)
					{
						Debug.Log("More than 1");
						return mInstance;
					}
				}
				//没有该类型的单例的时候 创建这个单例
				if (mInstance==null)
				{
					var instanceName = typeof(T).Name;
					var instaceObj = GameObject.Find(instanceName);
					if (!instaceObj)
					{
						instaceObj = new GameObject(instanceName);
					}
					mInstance = instaceObj.AddComponent<T>();
					DontDestroyOnLoad(instaceObj);
					Debug.Log("add new gameObject" + mInstance.name);
				}
				else
				{
					Debug.Log("Already exit :"+ mInstance.name);
				}
				return mInstance;
			}
		}

		protected virtual void OnDestroy()
		{
			mInstance = null;
		}
	}

}
