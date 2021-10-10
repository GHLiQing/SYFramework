using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework;
/// <summary>
/// 对象池管理类
/// </summary>
public class TF_ObjectPoolManager : MonoSingleton<TF_ObjectPoolManager>
{
	#region 字段  对象池集合 用来管理每个对象池 对应的名字
	private Dictionary<string, TF_ObjectPool> mPools = new Dictionary<string, TF_ObjectPool>();
	#endregion

	#region 方法
	/// <summary>
	/// 从对象池取出对象
	/// </summary>
	public GameObject Spawn(TF_PerfabsType type,string name,Vector3 pos,Quaternion quaternion,Transform parent=null)
	{
		GameObject obj = null;
		TF_ObjectPool pool = null;
		//如果对象池中没有 则注册进去 然后再取出来
		if (!mPools.ContainsKey(name))
		{
			//创建对象池
			RegisterPool(type,name);
		}
		
		pool = mPools[name];
		obj = pool.Spawn();//获得这个游戏物体
						   //得到这个物体进行位置 旋转 和父物体 进行初始化
		obj.transform.SetParent(parent);
		obj.transform.position = pos;
		obj.transform.rotation = quaternion;
		
		return obj;
	}
	/// <summary>
	/// 对象池回收物体
	/// </summary>
	public void UnSpawn(GameObject obj)
	{
		//mPools[obj.name].UnSpawn(obj);
		foreach (TF_ObjectPool item in mPools.Values)
		{
			if (item.Contains(obj))
			{
				//调用这个接口
				item.UnSpawn(obj);
				return;
			}
		}
		//如果改对象没有使用对象池，直接删除
		Destroy(obj);
	}
	/// <summary>
	/// 回收所有对象池对象
	/// </summary>
	public void UnSpawnAll()
	{
		foreach (TF_ObjectPool item in mPools.Values)
		{
			item.UpSpawnAll();
		}
	}

	/// <summary>
	/// 注册一个对象池
	/// </summary>
	/// <param name="type"></param>
	/// <param name="name"></param>
	private void RegisterPool(TF_PerfabsType type,string name)
	{
		string path = TF_ResourcesPath.Instance. GetPath(type, name);
		GameObject obj = TF_ResourcesFactory.Instance.Load<GameObject>(path);
		TF_ObjectPool pool = new TF_ObjectPool(obj); //通过构造方法来实现对象池的使用
		mPools.Add(name, pool);
	}
	#endregion
}
