using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.Example
{
	public class GameDateExample
	{
		/// <summary>
		/// ��Ӧʽ����
		/// </summary>
		public BindableProprety<int> Score = new BindableProprety<int>()
		{
			Valuse = 0
		};

		public BindableProprety<string> Name = new BindableProprety<string>()
		{
			Valuse = string.Empty
		};
	}
}

