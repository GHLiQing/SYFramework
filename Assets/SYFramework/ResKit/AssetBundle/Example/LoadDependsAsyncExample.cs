using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// “¿¿µº”‘ÿ≤‚ ‘
	/// </summary>
	public class LoadDependsAsyncExample : MonoBehaviour
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021 / Moudle /18 “Ï≤Ω“¿¿µº”‘ÿ≤‚ ‘  [New]", false, 18)]
		public static void MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying =true;

			new GameObject(nameof(LoadDependsAsyncExample)).AddComponent<LoadDependsAsyncExample>();

		}
#endif

		ResLoader mResLoader = new ResLoader();

		AssetBundle assetBundle;
		private void Awake()
		{
			mResLoader.LoadAsync<AssetBundle>("gameobject_prefabs", (objAssetBundle) => {

				assetBundle = objAssetBundle;
				var obj= assetBundle.LoadAsset("gameobject");
				Instantiate(obj);

			});
		}

		private void OnDestroy()
		{

			assetBundle = null;
			mResLoader.ReleaseAll();
			mResLoader = null;




		}
	}
}

