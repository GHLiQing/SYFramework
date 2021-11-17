using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
/// <summary>
/// 对象池类
/// </summary>
public class TF_ObjectPool 
{
	/// <summary>
	/// 需要实力化的预制体
	/// </summary>
	private GameObject mPrefab;

	public TF_ObjectPool(GameObject prefab)
	{
		this.mPrefab = prefab;
	}
	/// <summary>
	/// 对象池集合 
	/// </summary>
	private List<GameObject> ObjectList = new List<GameObject>();
	/// <summary>
	/// 返回一个对象
	/// </summary>
	/// <returns></returns>
   public GameObject Spawn()
	{

		GameObject obj = null;
		//取物体
		for (int i = 0; i < ObjectList.Count; i++)
		{
			//如果有一个物体隐藏的
			if (!ObjectList[i].activeInHierarchy)
			{
				obj = ObjectList[i];
				obj.SetActive(true);
				break;
			}
		}
	
		if (obj==null)
		{
			//创建一个
			obj = GameObject.Instantiate(mPrefab);
			ObjectList.Add(obj);//加入到集合中
		}
		//获取对象池接口  预制体挂在的脚本要继承这个接口，否则对象池使用不了
		TF_IReusable tF_IReusable = obj.GetComponent<TF_IReusable>();
		if (tF_IReusable != null)
		{
			tF_IReusable.OnSpawned();//这里在游戏物体身上调用会  TF_ObjectPoolManager.GetInstance.UnSpawn(gameObject); 进行回收 也就是说在获取这个游戏物体的时候就进行了回收处理
		}
		return obj;
	}
	/// <summary>
	/// 回收一个对象
	/// </summary>
	/// <param name="obj"></param>
	public void UnSpawn(GameObject obj)
	{
		Debug.LogError("回收");
		obj.SetActive(false);
		//获取对象池接口 
		TF_IReusable tF_IReusable = obj.GetComponent<TF_IReusable>();//游戏物体身上要继承这个接口 并且完成所需要的逻辑 进行回收处理
		if (tF_IReusable != null)
		{
			tF_IReusable.OnUpSpawned();
		}
	}
	/// <summary>
	/// 销毁所有
	/// </summary>
	public void UpSpawnAll()
	{
		foreach (GameObject obj in ObjectList)
		{
			obj.SetActive(false);
			//获取对象池接口 
			TF_IReusable tF_IReusable = obj.GetComponent<TF_IReusable>();
			if (tF_IReusable != null)
			{
				tF_IReusable.OnUpSpawned();
			}
		}
	}
	/// <summary>
	/// 判断是否存在
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	public bool Contains(GameObject obj)
	{
		return ObjectList.Contains(obj);
	}
}
