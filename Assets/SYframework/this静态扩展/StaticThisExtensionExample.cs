using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	
	public class StaticThisExtensionExample : MonoBehaviour
	{
		/// <summary>
		/// ��ʾ��Ϸ����
		/// </summary>
		private void ShowGameObje()
		{
			gameObject.SetActive(true);
		}

		/// <summary>
		/// ������Ϸ����
		/// </summary>
		private void HideGameobject()
		{
			gameObject.SetActive(false);
		}

	}

	/// <summary>
	/// ��̬��չ
	/// </summary>
	public  static class MonoExtension
	{
		public static void Show(this MonoBehaviour self)
		{
			Debug.Log("��ʾ");
			self.Show();
		}

		public static void Hide(this MonoBehaviour self)
		{
			Debug.Log("����");
			self.Hide();
		}

	}
}
