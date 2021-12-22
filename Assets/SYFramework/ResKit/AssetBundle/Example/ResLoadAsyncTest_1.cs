using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// Resources ·���²���
	/// </summary>
	public class ResLoadAsyncTest_1 : MonoBehaviour
	{
#if UNITY_EDITOR

		[UnityEditor.MenuItem("FrameworkDesign2021 / Moudle /17 Resources�첽���ز��� 2 [New]", false, 17)]
		public static void MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject(nameof(ResLoadAsyncTest_1)).AddComponent<ResLoadAsyncTest_1>();
		}
#endif

		ResLoader mResLoader = new ResLoader();
		private void Awake()
		{
			mResLoader.LoadAsync<Texture2D>("resources://UML��ͼ", obj => {

				Debug.Log(obj.name);
			});
			//mResLoader.LoadAsync<Texture2D>("resources://UML��ͼ", obj => {

			//	Debug.Log(obj.name);
			//});
			//mResLoader.LoadSync<Texture2D>("resources://UML��ͼ");
		}


		private void OnDestroy()
		{
			mResLoader.ReleaseAll();
			mResLoader = null;
		}
	}

}
