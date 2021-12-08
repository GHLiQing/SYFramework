using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace SYFramework.LQ
{
	public class ResourceReloadingExample : MonoBehaviour
	{
		[MenuItem("FrameworkDesign2021/Moudle/13 ��Դ�����ظ�������   (New)",false,13)]
		public static void ResourcesReloading()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject(typeof(ResourceReloadingExample).Name).AddComponent<ResourceReloadingExample>();
		}


		public void Awake()
		{
			var loadasset = Load<GameObject>("LoadCube");


		}

		private List<Object> resoucesList = new List<Object>();

		/// <summary>
		/// ��������ظ���Դ������
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name"></param>
		/// <returns></returns>
		public T Load<T>(string name) where T : Object
		{
			var res = resoucesList.Find(r => r.name == name) as T;

			if (!res)
			{
				res = Resources.Load<T>(name) as T;
				resoucesList.Add(res);
			}

			return res;
		}

		/// <summary>
		/// ж��
		/// </summary>
		public void  OnDestroy()
		{
			resoucesList.ForEach(loadAsset =>
			{
				if (loadAsset is GameObject)
				{
					loadAsset = null;
					Resources.UnloadUnusedAssets();
				}
				Resources.UnloadAsset(loadAsset);
			});
			resoucesList.Clear();
			resoucesList = null;
		}
	}
}
