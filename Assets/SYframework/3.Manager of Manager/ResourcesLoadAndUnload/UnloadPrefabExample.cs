using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ
{
	public class UnloadPrefabExample : MonoBehaviourSimplify
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/10.资源加载与卸载",false,10)]
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
			Resources.UnloadUnusedAssets();
			Debug.Log("卸载资源");
		}
		protected override void OnBeforOnDestroy()
		{
			
		}
	}
}

