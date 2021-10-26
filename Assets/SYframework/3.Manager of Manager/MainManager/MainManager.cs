using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ
{
	public enum EnvironmentMode
	{
		Developing, //开发阶段
		Test, //测试阶段
		Production //产品上线阶段
	}

	public abstract class MainManager : MonoBehaviourSimplify
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/2.游戏模块测试",false,2)]
		private static void MenuClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;
			new GameObject("MainManager").AddComponent<MainManager>().Mode=EnvironmentMode.Developing;
		}
#endif

		public EnvironmentMode Mode;

		private EnvironmentMode mSharedmode;
		private static bool mModeSetted = false;
		//在开发阶段需要一个有一个流程的
		//用于切换入口
		private void Awake()
		{
			if (!mModeSetted)
			{
				mModeSetted = true;
				mSharedmode = Mode; 
			}

			switch (mSharedmode)
			{
				case EnvironmentMode.Developing:

					LaunchInDevelopingMode();
					break;
				case EnvironmentMode.Test:

					LaunchInTestMode();
					break;
				case EnvironmentMode.Production:

					LaunchInProductionMode();
					break;
				default:
					break;
			}
		}

		protected abstract void LaunchInDevelopingMode();
		protected abstract void LaunchInTestMode();
		protected abstract void LaunchInProductionMode();
	}
}

