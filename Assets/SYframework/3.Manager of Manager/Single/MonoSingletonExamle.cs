using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ.single
{

	public class MonoSingletonExamle : MonoSingleton<MonoSingletonExamle>
	{
#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/8.MonoSington 测试", false, 8)]
		private static void MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;
		}

#endif
		//标签: 在游戏运行的时候才真正的执行
		//[RuntimeInitializeOnLoadMethod]
		private static void Example()
		{
			var instance = MonoSingletonExamle.Instance;
			var instance1 = Instance;
			if (instance==instance1)
			{
				Debug.Log("相等");
			}
			Debug.Log(instance.name);
		}
	}
}

