using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// 工具: 路径
	/// </summary>
	public class ResKitUtil
	{
		public static string FullPathforAssetBundleName(string assetBundleName)
		{
			return Application.streamingAssetsPath + "/AssetBundle/" + GetPlatformName() + "/" + assetBundleName;
		}

		public static string GetPlatformName()
		{
#if UNITY_EDITOR
			return GetPlatformName(UnityEditor.EditorUserBuildSettings.activeBuildTarget);
#else
			return GetPlatformName();
#endif
		}


		static string GetPlatformName(RuntimePlatform runtimePlatform)
		{
			switch (runtimePlatform)
			{
				case RuntimePlatform.OSXEditor:
				case RuntimePlatform.OSXPlayer:
					return "OSX";
				case RuntimePlatform.WindowsPlayer:
				case RuntimePlatform.WindowsEditor:
					return "Windows";
				case RuntimePlatform.IPhonePlayer:
					return "Android";

				case RuntimePlatform.Android:
					return "Android";

				case RuntimePlatform.LinuxPlayer:
				case RuntimePlatform.LinuxEditor:
					return "Linux";
				case RuntimePlatform.WebGLPlayer:
					return "WebGL";

				case RuntimePlatform.XboxOne:
					return "XboxOne";
				case RuntimePlatform.tvOS:
					return "tvOS";
				case RuntimePlatform.Switch:
					return "Switch";

				case RuntimePlatform.PS5:
					return "PS5";
				default:
					break;
			}
			return null;
		}

#if UNITY_EDITOR

		/// <summary>
		///  获取平台
		/// </summary>
		/// <returns></returns>
		static string GetPlatformName(UnityEditor.BuildTarget buildTarget)
		{
			switch (buildTarget)
			{
				case UnityEditor.BuildTarget.StandaloneWindows64:
				case UnityEditor.BuildTarget.StandaloneWindows:
					return "Windows";
				case UnityEditor.BuildTarget.iOS:
					return "iOS";
				case UnityEditor.BuildTarget.Android:
					return "Android";
				case UnityEditor.BuildTarget.WebGL:
					return "WebGL";
				
				case UnityEditor.BuildTarget.StandaloneLinux64:
					return "Linux";
				case UnityEditor.BuildTarget.Switch:
					return "Switch";
				case UnityEditor.BuildTarget.PS5:
					return "PS5";
				case UnityEditor.BuildTarget.NoTarget:
					break;
				default:
					break;
			}

			return null;
		}

#endif
	}


}

