using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class ExtensionMono : MonoBehaviour
	{
		private void Awake()
		{
			this.DoSomething().
				Hide();
		}

		
	}



	/// <summary>
	/// this ��չ������ �����Լ�
	/// 
	/// return selfcomponten;
	/// return self;
	/// </summary>
	public static class MonoBehaviourExtension
	{

		/// <summary>
		/// ����Լ�� component
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="selfcomponten"></param>
		/// <returns></returns>
		public static T Hide<T>(this T selfcomponten) where T : Component
		{
			selfcomponten.gameObject.SetActive(false);
			return selfcomponten;
		}

		public static T DoSomething<T>(this T self) where T : MonoBehaviour
		{
			self.name = "DoSomething";
			return self;
		}
	}
}
