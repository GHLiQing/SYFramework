using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
namespace Reskit
{
	public class AssetBundleExample : MonoBehaviour
	{
#if UNITY_EDITOR

		[UnityEditor.MenuItem("FrameworkDesign2021 /Moudle/14 AssetBundleExmaple [NEW]/Run AssetBundle [New]", false, 14)]
		public static void MenuOnClick2()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject(nameof(AssetBundleExample)).AddComponent<AssetBundleExample>();
		}


#endif

		private ResLoader resLoader = new ResLoader();

		private AssetBundle assetBundle;
		private void Awake()
		{
			//ab 加载方式直接给路径
			assetBundle = resLoader.LoadSync<AssetBundle>("gameobject_prefabs");
			
			var go= assetBundle.LoadAsset<GameObject>("gameobject");
			Instantiate(go);
		}

		private void OnDestroy()
		{
			resLoader.ReleaseAll();
			resLoader = null;
			
		}
	}

}
