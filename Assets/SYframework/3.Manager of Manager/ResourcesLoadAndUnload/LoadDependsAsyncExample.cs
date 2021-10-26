using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
namespace SYFramework.LQ.single
{
	public class LoadDependsAsyncExample : MonoBehaviour
	{

		#region UNITYEDITOR
		[MenuItem("FrameworkDesign2021/Moudle/15.LoadDependsAsyncExample 依赖包加载测试", false,15)]
		private static void MenuOnClick()
		{
			EditorApplication.isPlaying = true;

			new GameObject("LoadDependsAsyncExample").AddComponent<LoadDependsAsyncExample>();
		}
		#endregion


		private ResLoaderAsset loaderAsset = new ResLoaderAsset();

		private AssetBundle assetBundle;

		private void Awake()
		{
			loaderAsset.LoadAsync<AssetBundle>(Application.streamingAssetsPath + "/sphere_prefab", gameAssetBundle => {

				assetBundle = gameAssetBundle;
				var ga = assetBundle.LoadAsset<GameObject>("Sphere");
				Instantiate(ga);
			});
		}

		private void OnDestroy()
		{
			assetBundle = null;

			loaderAsset.ReleaseAll();

			loaderAsset = null;
		}
	}

}
