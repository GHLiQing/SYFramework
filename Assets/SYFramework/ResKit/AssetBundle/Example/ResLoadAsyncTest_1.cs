using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// Resources 路径下测试
	/// </summary>
	public class ResLoadAsyncTest_1 : MonoBehaviour
	{
#if UNITY_EDITOR

		[UnityEditor.MenuItem("FrameworkDesign2021 / Moudle /17 Resources异步加载测试 2 [New]", false, 17)]
		public static void MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject(nameof(ResLoadAsyncTest_1)).AddComponent<ResLoadAsyncTest_1>();
		}
#endif

		ResLoader mResLoader = new ResLoader();
		private void Awake()
		{
			mResLoader.LoadAsync<Texture2D>("resources://UML类图", obj => {

				Debug.Log(obj.name);
			});
			//mResLoader.LoadAsync<Texture2D>("resources://UML类图", obj => {

			//	Debug.Log(obj.name);
			//});
			//mResLoader.LoadSync<Texture2D>("resources://UML类图");
		}


		private void OnDestroy()
		{
			mResLoader.ReleaseAll();
			mResLoader = null;
		}
	}

}
