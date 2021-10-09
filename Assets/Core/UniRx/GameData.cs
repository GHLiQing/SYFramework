using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace SYFramework
{

	public static class GameData
	{
		/// <summary>
		/// œÏ”¶ Ω Ù–‘
		/// </summary>
		public static IntReactiveProperty Score = new IntReactiveProperty { Value = 0 };

		public static StringReactiveProperty Name= new StringReactiveProperty {Value="" };
	}

}
