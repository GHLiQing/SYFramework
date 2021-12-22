using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{

	/// <summary>
	/// 卸载资源
	/// </summary>
	public class UnloadPrefabExample : MonoBehaviour
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/10.资源加载与卸载   (NEW)",false,10)]
		private static void MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;
			new GameObject("UnloadPrefabExample").AddComponent<UnloadPrefabExample>();
		}
#endif

		IEnumerator Start()
		{
			var loadcube = Resources.Load<GameObject>("LoadCube");
			Instantiate(loadcube);
			yield return new WaitForSeconds(10f);
			loadcube = null;
			Resources.UnloadUnusedAssets(); //自能卸载没有引用的资源 上一句loadcube = null 才可以卸载
			Debug.Log("卸载资源");
		}



		/// <summary>
		/// 普通资源卸载
		/// 直接使用 Resources.UnloadAsset
		/// 
		/// </summary>
		/// <returns></returns>
		IEnumerator LoadAndUnLoad()
		{
			var clip = Resources.Load<AudioClip>("bg");

			Debug.Log("加载资源完成");
			yield return new WaitForSeconds(5f);

			Resources.UnloadAsset(clip);

			Debug.Log("卸载资源完成");
			
		}
	}
}

