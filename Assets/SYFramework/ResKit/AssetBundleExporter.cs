using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
namespace SYFramework.LQ
{
	public class AssetBundleExporter : MonoBehaviour
	{
#if UNITY_EDITOR

		//[MenuItem("FrameworkDesign2021/Moudle/AssetAbudleExporter", false, 16)]
		public static void MenuOnClick()
		{
			var outputPath = Application.streamingAssetsPath + "/AssetBundles/" + GetPlatformName();

			if (!Directory.Exists(outputPath))
			{
				Directory.CreateDirectory(outputPath);
			}
			//打包
			BuildPipeline.BuildAssetBundles(outputPath,BuildAssetBundleOptions.ChunkBasedCompression,
				EditorUserBuildSettings.activeBuildTarget);
			AssetDatabase.Refresh();
		}

		public static string GetPlatformName()
		{
			switch (EditorUserBuildSettings.activeBuildTarget)
			{

				case BuildTarget.StandaloneWindows:
					
				case BuildTarget.StandaloneWindows64:
					return "Windows";
				case BuildTarget.iOS:
					return "ios";

				case BuildTarget.Android:
					return "Android";
				case BuildTarget.StandaloneLinuxUniversal:
				case BuildTarget.StandaloneLinux64:
				case BuildTarget.StandaloneLinux:
					return "StandaloneLinux";

				case BuildTarget.WebGL:
					return "WebGL";
		
				
				case BuildTarget.XboxOne:
					return "XboxOne";

				
			}
			return null;
		}

#endif
	}

}
