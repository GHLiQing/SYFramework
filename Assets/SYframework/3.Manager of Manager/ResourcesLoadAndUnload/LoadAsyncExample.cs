using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.LQ.single
{
	public class LoadAsyncExample : MonoBehaviour
	{

		#region UNITYEDITOR

		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/14.LoadAsyncExample", false, 14)]
		private static void MeneOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject("LoadAsyncExample").AddComponent<LoadAsyncExample>();
		}
		#endregion

		ResLoaderAsset loaderAsset;
		private void Start()
		{
			loaderAsset = new ResLoaderAsset();
			//assetName ：包名 （不是资源名）
			loaderAsset.LoadAsync<AssetBundle>(Application.streamingAssetsPath + "/sphere_prefab", sphere =>
			{

				Debug.Log("ab 加载资源" + sphere.name);
			});
			//loaderAsset.LoadAsync<GameObject>("resources://LoadCube", sphere =>
			//{
			//	Debug.Log("资源名字1:" + sphere.name);

			//});

			//var go= loaderAsset.LoadSync<GameObject>(Application.streamingAssetsPath+ "/sphere_prefab");
			//Instantiate(go);

		}
		private void OnDestroy()
		{
			loaderAsset.ReleaseAll();
			loaderAsset = null;


		}
	}

}
