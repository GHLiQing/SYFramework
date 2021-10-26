using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace SYFramework.LQ
{
	/// <summary>
	/// 关卡管理
	/// </summary>
	public class LevelManager
	{
		private static List<string> mLevelName;

		public static int Index { get; set; }

		public static void Init(List<string> levelName)
		{
			Index = 0;
			mLevelName = levelName;

		}

		public static void LoadCurrentLevel()
		{
			
			SceneManager.LoadScene(mLevelName[Index]);
		}

		public static void LoadNext(System.Action actionCallback)
		{
			Index++;
			if (Index>=mLevelName.Count)
			{
				Index = 0;
			}
			SceneManager.LoadScene(mLevelName[Index]);
			actionCallback?.Invoke();
		}

	}

}
