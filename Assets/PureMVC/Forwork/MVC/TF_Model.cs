using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 模型类 继承即可
/// </summary>
public  abstract class TF_Model 
{
	/// <summary>
	/// model 的名字
	/// </summary>
	public abstract string Name { get; }

	/// <summary>
	/// 发送通知
	/// </summary>
	/// <param name="name"> 事件的名字</param>
	/// <param name="data">事件执行的参数</param>
	public virtual void SendNotification(string name,object data=null) {
		TF_PureMVC.SendMsg(name, data);
	}

	



}
