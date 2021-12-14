using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
namespace Reskit
{
	public class AssetBundleExample : MonoBehaviour
	{
#if UNITY_EDITOR

		[UnityEditor.MenuItem("FrameworkDesign2021 /Moudle/14 AssetBundleExmaple/Build AssetBundle [New]",false,14)]
		public static void MenuOnClick1()
		{
			if (!Directory.Exists(Application.streamingAssetsPath))
			{
				Directory.CreateDirectory(Application.streamingAssetsPath);
			}
			UnityEditor.BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath,
				UnityEditor.BuildAssetBundleOptions.None,
				UnityEditor.BuildTarget.StandaloneWindows);
		}

		[UnityEditor.MenuItem("FrameworkDesign2021 /Moudle/14 AssetBundleExmaple/Run AssetBundle [New]", false, 14)]
		public static void MenuOnClick2()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject(nameof(AssetBundleExample)).AddComponent<AssetBundleExample>();
		}


#endif

		private AssetBundle assetBundle;
		private void Awake()
		{
			assetBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/sphareab");
			var go= assetBundle.LoadAsset<GameObject>("sphareab");
			Instantiate(go);
		}

		private void OnDestroy()
		{
			assetBundle.Unload(true);
		}
	}

}
