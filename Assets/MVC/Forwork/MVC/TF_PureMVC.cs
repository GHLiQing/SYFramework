using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 总的控制器
/// </summary>
public class TF_PureMVC
{
	private static Dictionary<string, TF_Model> Models = new Dictionary<string, TF_Model>();
	private static Dictionary<string, TF_View> Views = new Dictionary<string, TF_View>();
	/// <summary>
	///反射  
	/// </summary>
	private static Dictionary<string, Type> Commands = new Dictionary<string, Type>();

	#region model
	/// <summary>
	/// 注册model
	/// </summary>
	/// <param name="model"></param>
	public static void RegistModel(TF_Model model)
	{
		if (!Models.ContainsKey(model.Name))
		{
			Models.Add(model.Name, model);
		}
	}

	/// <summary>
	/// 取消注册model
	/// </summary>
	/// <param name="tF_Model"></param>
	public static void UnRegistModel(TF_Model tF_Model)
	{
		if (Models.ContainsKey(tF_Model.Name))
		{
			Models.Remove(tF_Model.Name);
		}
	}
	/// <summary>
	/// 遍历之后获取需要的model
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="name"></param>
	/// <returns></returns>
	public static T GetModel<T>(string name) where T : TF_Model
	{
		foreach (var item in Models.Keys)
		{
			if (item.Equals(name))
			{
				return Models[name] as T;
			}
		}
		return null;
	}

	#endregion

	#region view
	public static void RegistView(TF_View view)
	{
		if (!Views.ContainsKey(view.Name))
		{
			Views.Add(view.Name, view);
			view.AddInterestNotifiaction();//注册视图之后执行的方法
		}
	}
			

	public static void UnRegistView(TF_View view)
	{
		if (Views.ContainsKey(view.Name))
		{
			Views.Remove(view.Name);
		}
	}


	public static T GetView<T>(string name) where T : TF_View
	{
		foreach (var item in Views.Keys)
		{
			if (item.Equals(name))
			{
				return Views[name] as T;
			}
		}
		return null;
	}

	#endregion

	#region Command  命令
	public static void RegisterCommand(string name, Type type)
	{
		if (!Commands.ContainsKey(name))
		{
			
			Commands.Add(name, type);
		}
	}

	public static void UnRegisterCommand(string name)
	{
		if (Commands.ContainsKey(name))
		{
			Commands.Remove(name);
		}
	}

	/// <summary>
	/// 处理事件
	/// </summary>
	/// <param name="name"></param>
	/// <param name="data"></param>
	public static void SendMsg(string name, object data = null)
	{
		//判断我们的事件是否存在
		if (Commands.ContainsKey(name))
		{
			//使用命令对象  用完之后释放
			TF_Controller commnd = Activator.CreateInstance(Commands[name]) as TF_Controller;
			commnd.Execute(data);
			//var changescen=  Commands[name] as ChangeScene;
			//changescen.Execute(data);
			
		}
		//判断视图是否关注该事件，如果关注，则执行事件
		foreach (TF_View item in Views.Values)
		{
			if (item.ContainsNotification(name))
			{
				item.HandleNotification(name, data);
			}
		}
	}
	#endregion


	
}

interface CommadType
{
	void Execute(object data);
}
public class ChangeScene : CommadType
{
	public void Execute(object data)
	{
		Debug.Log("data:" + data);
	}
}
