using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  开始命令
/// </summary>
public class StartUpCommand : TF_Controller
{
	
	public override void Execute(object data = null)
	{
		RegistCommand(NotificationConst.LoadSceneCommand, typeof(LoadSceneCommand));
	}
}
