using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework.LQ;
using UnityEngine.SceneManagement;
namespace Game
{


	/// <summary>
	/// 作为游戏模块的入口
	/// </summary>
	public class GameModule : MainManager
	{

		public static void LoadModule()
		{
			SceneManager.LoadScene("Game");
		}
		protected override void LaunchInDevelopingMode()
		{
			//开发逻辑
			//加载资源
			//初始化sdk
			//game 的一些逻辑准备 角色选择，准备一些假的数据
			Debug.Log("开发逻辑");
		}

		protected override void LaunchInProductionMode()
		{
			//正常的开发逻辑
			Debug.Log("生产逻辑");
		}

		protected override void LaunchInTestMode()
		{
			//正常的开发逻辑
			Debug.Log("测试逻辑");

		}

		protected override void OnBeforOnDestroy()
		{
			
		}
	}

}
