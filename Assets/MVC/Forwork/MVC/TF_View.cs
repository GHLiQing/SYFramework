using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 视图类
/// </summary>
public  abstract  class TF_View :MonoBehaviour
{
	/// <summary>
	/// View 的名字
	/// </summary>
	public abstract string Name { get; }
	/// <summary>
	/// 发送通知
	/// </summary>
	/// <param name="name"> 事件的名字</param>
	/// <param name="data">事件执行的参数</param>
	public virtual void SendNotification(string name, object data = null) {

		//发送指令给puremvc 进行处理 中转到mvc
		TF_PureMVC.SendMsg(name, data);
	}

	/// <summary>
	/// 获取模型
	/// </summary>
	/// <typeparam name="T"> 泛型</typeparam>
	/// <param name="name">模型的名字</param>
	/// <returns></returns>
	public T GetModel<T>(string name) where T : TF_Model
	{
		return TF_PureMVC.GetModel<T>(name) ;
	}

	/// <summary>
	/// 保存该兴趣的通知
	/// </summary>
	private  List<string> InterestNotification = new List<string>();
	public bool ContainsNotification(string name)
	{
		return InterestNotification.Contains(name);
	}
	/// <summary>
	/// 注册视图之后执行的方法
	/// </summary>
	public virtual void AddInterestNotifiaction()
	{
		
	}
	/// <summary>
	/// 处理 model中的事件
	/// </summary>
	/// <param name="name">事件的名字</param>
	/// <param name="data">事件的参数</param>
	public virtual void HandleNotification(string name ,object data = null)
	{

	}

}
