using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 整个游戏控制类
/// </summary>
public class GameManager :AppFacde
{
	
	private void Start()
	{
		//注册开启游戏命令
		RegisterCommand(NotificationConst.StartUpCommand, typeof(StartUpCommand));

		SendNotification(NotificationConst.StartUpCommand);
	}
}
