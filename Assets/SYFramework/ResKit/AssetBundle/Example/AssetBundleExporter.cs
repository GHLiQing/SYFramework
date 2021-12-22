using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Reskit
{
	public class AssetBundleExporter : MonoBehaviour
	{
#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021 /Moudle/14 AssetBundleExmaple [NEW]/Build AssetBundle [New]", false, 14)]
		public static void MenuOnClick1()
		{
			var outPath = Application.streamingAssetsPath + "/AssetBundle/" + ResKitUtil.GetPlatformName();
			if (!Directory.Exists(outPath))
			{
				Directory.CreateDirectory(outPath);
			}
			UnityEditor.BuildPipeline.BuildAssetBundles(outPath,
				 UnityEditor.BuildAssetBundleOptions.ChunkBasedCompression, UnityEditor. EditorUserBuildSettings.activeBuildTarget);

			UnityEditor.AssetDatabase.Refresh();
		}


	

#endif



	}

}
