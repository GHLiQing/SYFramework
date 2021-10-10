using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LQFramework
{
    public abstract class UtilsSinglton<T> where  T:UtilsSinglton<T>
    {

        protected static T mSinglton = null;

        protected UtilsSinglton()
        {
            
            
        }

        public static T Instance
        {
            get
            {
                if (mSinglton==null)
                {
                    var cotors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

                    var cotor = System.Array.Find(cotors, c => c.GetParameters().Length == 0);

                    if (cotor==null)
                    {
                        Debug.Log("没有找到相应实例");
                        
                    }

                    mSinglton = cotor.Invoke(null) as T;

                }

                return mSinglton;
            }
        }
        


    }

	/// <summary>
	///  unity 生命周期的单例模式
	/// </summary>
	/// <typeparam name="T"></typeparam>
    public class UtilsMonoSingiton<T> : MonoBehaviour where T : UtilsMonoSingiton<T>
    {
		protected static T instance = null;

		public static T Instance
		{
			get
			{
				if (instance==null)
				{
					instance = FindObjectOfType<T>();
					if (FindObjectsOfType<T>().Length>1)
					{
						return instance;
					}
					if (instance==null)
					{
						string instanceName = typeof(T).Name;
						Debug.Log("Instance name: " + instanceName);
						GameObject instanceGo = GameObject.Find(instanceName);

						if (instanceGo == null)
							instanceGo = new GameObject(instanceName);
						instance = instanceGo.AddComponent<T>();
						DontDestroyOnLoad(instanceGo);
						Debug.Log("Add New Singleton" + instance.name);
					}
					else
					{
						Debug.Log("Already Eexit"+instance.name);
					}
				}
				return instance;
			}
		}


		protected virtual void OnDestroy()
		{
			instance = null;
		}
    }
}
 