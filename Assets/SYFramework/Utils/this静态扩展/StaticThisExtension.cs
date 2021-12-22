using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SYFramework
{
	public static class StaticThisExtension
	{
#if UNITY_EDITOR

		[MenuItem("FrameworkDesign2021/Moudle/9.this 静态扩展", false, 9)]
		private static void MeneOnClick()
		{
			var go = new GameObject();
			go.Test();
		}
#endif

		/// <summary>
		/// this 后面的GameObject 就是可以调用 Test这个方法
		/// </summary>
		/// <param name="self"></param>
		public static void Test(this GameObject self)
		{
			Debug.Log(self.GetType());
		}
	}

}
