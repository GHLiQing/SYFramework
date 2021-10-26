using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace SYFramework.LQ
{
	public class ResolutionCheck
	{
		
#if UNITY_EDITOR
		[MenuItem("FrameworkDesign2021/获取屏幕分辨率")]
		private static void MencClicked()
		{
			Debug.Log(IsPadResolution() ? "是 Pad 分辨率" : "不是 Pad 分辨率");
			Debug.Log(IsPhoneResolution() ? "是 Phone 分辨率" : "不是 Phone 分辨率");
			Debug.Log(IsiPhoneXrResolution() ? "是 iPhone X 分辨率" : "不是 iPhone X 分辨率");
		}
#endif

		/// <summary>
		///获取屏幕的宽高比值
		/// </summary>
		/// <returns></returns>
		public static float GetAspectRation()
		{
			return Screen.width > Screen.height ? (float)Screen.width / Screen.height : (float)Screen.height / Screen.width;

		}

		/// <summary>
		/// 是否是pad的分辨率4：3
		/// </summary>
		/// <returns></returns>
		public static bool IsPadResolution()
		{
			var aspect = GetAspectRation();
			return aspect > 4.0f / 3 - 0.05f && aspect < 4.0f / 3 + 0.05f;
		}

		/// <summary>
		/// 是否是手机分辨率 16.：9 
		/// </summary>
		/// <returns></returns>
		public static bool IsPhoneResolution()
		{
			var aspece = GetAspectRation();
			return aspece > 16.0f / 9 - 0.05f && aspece < 16.0f / 9 + 0.05f;
		}
		/// <summary>
		/// 是否是iphonexr 的分辨率2436：1125
		/// </summary>
		/// <returns></returns>
		public static bool IsiPhoneXrResolution()
		{
			var aspect = GetAspectRation();
			return aspect > 2436.0 / 1125 - 0.05f && aspect < 2436.0f / 1125 + 0.05f;
		}


	}
}

