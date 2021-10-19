using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{
	public  class NomalProprety :MonoBehaviour
	{
		private static string values;

		public static string Values
		{
			get => values;
			set
			{
				if (!values.Equals(value))
				{
					values = value;
					callback?.Invoke(value);
				}
			}
		}

		public static Action<string> callback;



		private void Awake()
		{
			callback = (va) => {

				Debug.Log("va:" + va);
			};



		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Values = "Êó±êµã»÷ÁË";
			}
		}
	}



}

