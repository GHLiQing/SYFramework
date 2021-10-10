using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace QFramework.LQ
{
	public static class StaticThisExtension
	{
#if UNITY_EDITOR

		[MenuItem("FrameworkDesign2021/Moudle/9.this 静态扩展", false, 9)]
		private static void MeneOnClick()
		{
			//new object().Test();
		}
#endif

		public static void Test(this GameObject self)
		{
			Debug.Log(self.GetType());
		}
	}

}
