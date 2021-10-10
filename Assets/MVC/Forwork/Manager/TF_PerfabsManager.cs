using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework;
/// <summary>
/// 预制体管理器
/// </summary>
public class TF_PerfabsManager : Single<TF_PerfabsManager>
{
  /// <summary>
  /// 加载预制体
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="name"></param>
  /// <returns></returns>
	public GameObject Spawn(TF_PerfabsType type, string name,Vector3 pos=default,Quaternion quaternion=default)
	{
		//路径
		string path = TF_ResourcesPath.Instance.GetPath(type,name);

		GameObject obj= TF_ResourcesFactory.Instance.Load<GameObject>(path);
		if (obj!=null)
		{
			GameObject.Instantiate<GameObject>(obj,pos, quaternion);
		}
		else
		{
			Debug.Log("为空");
		}

		return obj;
		
	}
	/// <summary>
	/// 重载
	/// </summary>
	/// <param name="type"></param>
	/// <param name="name"></param>
	/// <returns></returns>
	public GameObject Spawn(TF_PerfabsType type, string name)
	{
		return Spawn(type,name,Vector3.zero,Quaternion.identity);
	}

}
