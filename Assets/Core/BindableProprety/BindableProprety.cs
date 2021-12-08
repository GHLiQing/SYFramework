using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework.Example
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
				values = value;
				onRecive?.Invoke(value);
			}
		}

		public Action<T> onRecive=(value)=> { };

		public IUnRegister Regsiter(Action<T> onEvent)
		{
			onRecive += onEvent;
			return new BindablePropretyUnRegister<T>()
			{
				bindableProprety = this,
				OnEvent = onEvent
			};
		}

		public void UnRegisterOnValueChanged(Action<T> onEvent)
		{
			onRecive -= onEvent;
		}
		
	}

	public class BindablePropretyUnRegister<T> : IUnRegister
	{
		public BindableProprety<T> bindableProprety { get; set; }

		public Action<T> OnEvent { get; set; }
		public void UnRegister()
		{
			bindableProprety.UnRegisterOnValueChanged(OnEvent);
		
		}
	}


}
