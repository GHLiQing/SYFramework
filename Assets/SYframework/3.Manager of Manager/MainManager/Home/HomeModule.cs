using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework.LQ;
namespace Game
{
	public class HomeModule : MainManager
	{


		protected override void LaunchInDevelopingMode()
		{
			//开发阶段
		}

		protected override void LaunchInProductionMode()
		{
			//上线阶段
			//测试逻辑
			//加载资源
			//初始化sdk
			//点击开始游戏
			Delay(5f, () =>
			{
				GameModule.LoadModule();
			});
			
		}

		protected override void LaunchInTestMode()
		{
			//测试
			//产生逻辑
			//加载资源
			//初始化sdk
			//点击开始游
			//GameModule.LoadModule();
		}

		protected override void OnBeforOnDestroy()
		{
			
		}
	}

}
