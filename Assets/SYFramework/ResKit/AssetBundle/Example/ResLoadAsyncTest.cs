using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// AB º”‘ÿ≤‚ ‘
	/// </summary>
	public class ResLoadAsyncTest : MonoBehaviour
	{
#if UNITY_EDITOR

		[UnityEditor.MenuItem("FrameworkDesign2021 / Moudle /16 AssetBundle“Ï≤Ωº”‘ÿ≤‚ ‘ 1 [New]", false,16)]
		public static void MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject(nameof(ResLoadAsyncTest)).AddComponent<ResLoadAsyncTest>();
		}
#endif


		ResLoader mResLoader = new ResLoader();

		private void Awake()
		{
			mResLoader.LoadAsync<AssetBundle>("titesprite", obj =>
			{

				Debug.Log(obj.name);
			});
			mResLoader.LoadAsync<AssetBundle>("gameobject_prefabs", obj =>
			{
				Debug.Log(obj.name);
			});
			//mResLoader.LoadSync<AssetBundle>(Application.streamingAssetsPath+ "titesprite");

		}


		private void OnDestroy()
		{
			mResLoader.ReleaseAll();
			mResLoader = null;
		}
	}

}
