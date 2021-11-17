using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	
	public class StaticThisExtensionExample : MonoBehaviour
	{

		private void Awake()
		{
			//ֱ��this ����
			this.Show();
			this.Hide();
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
			self.gameObject.SetActive(true);
		}

		public static void Hide(this MonoBehaviour self)
		{
			Debug.Log("����");
			self.gameObject.SetActive(false);
		}

	}
}
