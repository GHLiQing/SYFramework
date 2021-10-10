using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SYFramework;
/// <summary>
/// 使用 appfaced 基类
/// </summary>
public class AppFacde : MonoSingleton<AppFacde>
{
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	/// <summary>
	/// 注册消息
	/// </summary>
	/// <param name="name"></param>
	/// <param name="type"></param>
	public void RegisterCommand(string name,Type type)
	{
		TF_PureMVC.RegisterCommand(name, type);
		//SY_PureMVC.RegisterCommand(name, type);
	}

	public void SendNotification(string name,object data=null)
	{
		TF_PureMVC.SendMsg(name, data);
		//SY_PureMVC.SendSmg(name, data);
	}

}
