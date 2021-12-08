using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public enum PrefabsType
	{
		prefab,//游戏物体
		audio,//音频
		texture //图片
	}

	public class ObjectPoolManager : UtilsMonoSingiton<ObjectPoolManager>
	{
		#region 字段
		private Dictionary<string, ObjectPool> mPoolsDic = new Dictionary<string, ObjectPool>();

		#endregion

		#region 方法

		public GameObject Spawn(PrefabsType type,string  name, Vector3 pos, Quaternion quaternion,Transform parent=null)
		{
			GameObject obj = null;
			ObjectPool objectPool = null;
			if (!mPoolsDic.ContainsKey(name))
			{
				Register(type, name);
			}
			objectPool = mPoolsDic[name];
			obj=objectPool.Spawn();
			obj.transform.SetParent(parent);
			obj.transform.position = pos;
			obj.transform.rotation = quaternion;
			return obj;
		}

		/// <summary>
		/// 回收
		/// </summary>
		/// <param name="obj"></param>
		public void UnSpawn(GameObject obj)
		{
			foreach (ObjectPool pool in mPoolsDic.Values)
			{
				if (pool.Contains(obj))
				{
					pool.UnSpawn(obj);
					return;
				}
				
			}
			//回收失败 直接删除
			Destroy(obj);
		}

		/// <summary>
		/// 回收所有
		/// </summary>
		public void UnSpawnAll()
		{
			foreach (ObjectPool pool in mPoolsDic.Values)
			{
				pool.UpSpawnAll();
			}
		}
		private void Register(PrefabsType type,string name)
		{
			string path = LoadType(type)+name;
			GameObject obj = Resources.Load<GameObject>(path);
			ObjectPool pool = new ObjectPool(obj);
			mPoolsDic.Add(name, pool);
		}

		private string  LoadType(PrefabsType type)
		{
			string path =string.Empty;
			switch (type)
			{
				case PrefabsType.prefab:
					return path = "Prefabs/";
					
				case PrefabsType.audio:
					return path = "Audio/";
				case PrefabsType.texture:
					return path = "Texture/";
				default:
					break;
			}
			return null;
		}
		#endregion
	}


}
