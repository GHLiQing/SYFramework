using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	
	public class StaticThisExtensionExample : MonoBehaviour
	{

		private void Awake()
		{
			//直接this 调用
			this.Show();
			this.Hide();
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
			self.gameObject.SetActive(true);
		}

		public static void Hide(this MonoBehaviour self)
		{
			Debug.Log("隐藏");
			self.gameObject.SetActive(false);
		}

	}
}
