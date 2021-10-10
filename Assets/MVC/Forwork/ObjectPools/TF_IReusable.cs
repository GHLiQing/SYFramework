using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 需要实力化的对象继承的接口
/// </summary>
public interface TF_IReusable 
{
	/// <summary>
	/// 对象从对象池实力化之后的回调
	/// </summary>
	void OnSpawned();
	/// <summary>
	/// 对象销毁之后的回调
	/// </summary>
	void OnUpSpawned();
}
