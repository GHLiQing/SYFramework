using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 通知器类
/// 
/// </summary>
public abstract class TF_Controller 
{

	/// <summary>
	/// 发送通知 view 视图中调用
	/// </summary>
	/// <param name="name"> 事件的名字</param>
	/// <param name="data">事件执行的参数</param>
	public abstract void Execute(object data = null);

	public T GetModel<T>(string name) where T : TF_Model
	{
		return TF_PureMVC.GetModel<T>(name);//从puremvc中的字典获取需要的模型
	}


	public T GetView<T>(string name) where T : TF_View
	{
		return TF_PureMVC.GetView<T>(name); //通过puremvc 返回一个 view  所提 puremvc是一个中中间类进行交换
	}

	/// <summary>
	/// 注册 view
	/// </summary>
	/// <param name="tF_View"></param>
	public void RegistView(TF_View tF_View)
	{
		TF_PureMVC.RegistView(tF_View);//通过控制器注册到puremvc中
	}
	/// <summary>
	/// 注册 model
	/// </summary>
	/// <param name="tF_Model"></param>
	public void RegistMode(TF_Model tF_Model)
	{
		TF_PureMVC.RegistModel(tF_Model);
	}

	/// <summary>
	/// 注册命令
	/// </summary>
	/// <param name="name"></param>
	/// <param name="type"></param>
	public void RegistCommand(string name,Type type)
	{
		TF_PureMVC.RegisterCommand(name, type);
	}
}
