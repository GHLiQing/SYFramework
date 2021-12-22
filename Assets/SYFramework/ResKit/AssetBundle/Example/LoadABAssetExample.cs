using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	public class LoadABAssetExample : MonoBehaviour
	{
#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021 / Moudle /19 LoadABAssetExample [New]", false, 19)]
		static void MenuClicked()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject("LoadABAssetExample")
				.AddComponent<LoadABAssetExample>();
		}
#endif

		private ResLoader mResLoader = new ResLoader();

		private AssetBundle mBundle;

		private void Start()
		{
			var tite = mResLoader.LoadSync<Texture2D>("titesprite", "tite");

			Debug.Log(tite.name);

			mResLoader.LoadAsync<GameObject>("gameobject_prefabs", "gameobject", gameObjectPrefab =>
			{
				Instantiate(gameObjectPrefab);
			});
		}

		private void OnDestroy()
		{
			mBundle = null;

			mResLoader.ReleaseAll();
			mResLoader = null;
		}
	}
}

