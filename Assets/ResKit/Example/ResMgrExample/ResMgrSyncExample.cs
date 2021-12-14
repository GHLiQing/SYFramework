using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Reskit
{
	/// <summary>
	/// 同步加载测试
	/// </summary>
	public class ResMgrSyncExample : MonoBehaviour
	{

#if UNITY_EDITOR

		[MenuItem("FrameworkDesign2021 / Moudle / 11.ResMgrSyncExample 同步加载  (New)", false,11)]
		public static void MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject(nameof(ResMgrSyncExample)).AddComponent<ResMgrSyncExample>();
		}


#endif
		ResLoader resLoader = new ResLoader();

		private void Awake()
		{
			var load = resLoader.LoadSync<GameObject>("LoadCube");
			Instantiate(load);

		}

		private void OnDestroy()
		{
			
		}
	}

}
