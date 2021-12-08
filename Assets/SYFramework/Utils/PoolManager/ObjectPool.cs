using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	/// <summary>
	/// 对象池
	/// </summary>
	public class ObjectPool
	{
		private GameObject mPrefab;

		public ObjectPool(GameObject prefab)
		{
			this.mPrefab = prefab;
			Debug.Log("名字："+mPrefab.name);
		}

		private List<GameObject> ObjectsList = new List<GameObject>();

		/// <summary>
		/// 创建实例
		/// </summary>
		/// <returns></returns>
		public GameObject Spawn()
		{
			GameObject obj = null;
			for (int i = 0; i < ObjectsList.Count; i++)
			{
				if (!ObjectsList[i].activeInHierarchy)
				{
					obj = ObjectsList[i];
					obj.SetActive(true);
					break;
				}
			}
			if (obj==null)
			{
				obj = GameObject.Instantiate(mPrefab);
				ObjectsList.Add(obj);
			}
			IReusable reusable = obj.GetComponent<IReusable>();
			if (reusable!=null)
			{
				reusable.OnSpawned();
			}

			return obj;
		}

		/// <summary>
		/// 回收
		/// </summary>
		/// <param name="obj"></param>
		public void UnSpawn(GameObject obj)
		{
			obj.SetActive(false);
			IReusable reusable = obj.GetComponent<IReusable>();
			if (reusable!=null)
			{
				reusable.OnUpSpawned();
			}
		}
		/// <summary>
		/// 销毁所有
		/// </summary>
		public void UpSpawnAll()
		{
			foreach (GameObject obj in ObjectsList)
			{
				obj.SetActive(false);
				IReusable reusable = obj.GetComponent<IReusable>();
				if (reusable != null)
				{
					reusable.OnUpSpawned();
				}
			}
		}

		public bool Contains(GameObject obj)
		{
			return ObjectsList.Contains(obj);
		}

	}

}
