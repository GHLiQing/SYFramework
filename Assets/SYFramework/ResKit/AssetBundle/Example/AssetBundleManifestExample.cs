using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Reskit
{
	/// <summary>
	/// “¿¿µ≤‚ ‘
	/// </summary>
	public class AssetBundleManifestExample : MonoBehaviour
	{
#if UNITY_EDITOR

		[UnityEditor.MenuItem("FrameworkDesign2021 /Moudle/15 AssetBundleManifestExample [New]", false, 15)]
		public static void MenuOnClick()
		{
			var assetBundle = AssetBundle.LoadFromFile(ResKitUtil.FullPathforAssetBundleName(ResKitUtil.GetPlatformName()));

			var mainifest= assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

			mainifest.GetAllAssetBundles()
				.ToList()
				.ForEach(obj=> {
					if (obj== "gameobject_prefabs")
					{
						Debug.Log(obj);
					}
				});

			mainifest.GetAllDependencies("gameobject_prefabs")
				.ToList()
				.ForEach(dep => {

					Debug.Log("gameobject_prefabs “¿¿µ£∫" + dep);
				});

			assetBundle.Unload(true);
		}
#endif

	
	}

}
