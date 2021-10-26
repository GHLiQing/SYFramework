using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	
	public class StaticThisExtensionExample : MonoBehaviour
	{
		/// <summary>
		/// 显示游戏物体
		/// </summary>
		private void ShowGameObje()
		{
			gameObject.SetActive(true);
		}

		/// <summary>
		/// 隐藏游戏物体
		/// </summary>
		private void HideGameobject()
		{
			gameObject.SetActive(false);
		}

	}

	/// <summary>
	/// 静态扩展
	/// </summary>
	public  static class MonoExtension
	{
		public static void Show(this MonoBehaviour self)
		{
			Debug.Log("显示");
			self.Show();
		}

		public static void Hide(this MonoBehaviour self)
		{
			Debug.Log("隐藏");
			self.Hide();
		}

	}
}
