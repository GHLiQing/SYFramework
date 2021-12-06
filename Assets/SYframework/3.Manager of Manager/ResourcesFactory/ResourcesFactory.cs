using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.Singleton
{
	/// <summary>
	/// ��Դ���ع���
	/// </summary>
	public class ResourcesFactory : SingletonNomal<ResourcesFactory>
	{
		protected ResourcesFactory() { }

		public T Load<T>(string path) where T : Object
		{
			return Resources.Load<T>(path);
		}

		public T LoadAsync<T>(string path) where T : Object
		{
			return Resources.LoadAsync<T>(path) as T;
		}
	}

}
