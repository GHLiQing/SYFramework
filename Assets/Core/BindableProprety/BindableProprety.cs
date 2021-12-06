using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{

	/// <summary>
	/// œÏ”¶ Ω Ù–‘
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BindableProprety<T>
	{
		
		private T values;

		public T Valuse
		{
			get => values;

			set
			{
				if (!values.Equals(value))
				{
					values = value;
					onRecive?.Invoke(value);
				}
			}
		}

		private Action<T> onRecive;
	}

}
