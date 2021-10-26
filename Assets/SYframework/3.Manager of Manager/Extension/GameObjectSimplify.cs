using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ
{
	/// <summary>
	/// 静态this 扩展
	/// 写法: 静态类
	///  静态共有方法 方法参数 带this关键字 
	///  partial 关键字 用于扩展类
	/// </summary>
	public static partial class GameObjectExtension
	{
		public static void Show(this GameObject go)
		{
			go.SetActive(true);
		}

		public static void Hide(this GameObject go)
		{
			go.SetActive(false);
		}

		public static void Show(this Transform transform)
		{
			transform.gameObject.SetActive(true);
		}
		public static void Hide(this Transform transform)
		{
			transform.gameObject.SetActive(false);
		}

		public static void Show(this MonoBehaviour monoBehaviour)
		{
			monoBehaviour.gameObject.SetActive(true);
		}

		public static void Hide(this MonoBehaviour monoBehaviour)
		{
			monoBehaviour.gameObject.SetActive(false);
		}
	}
}

