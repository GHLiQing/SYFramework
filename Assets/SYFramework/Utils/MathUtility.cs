using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.Core
{
	public class MathUtility
	{

		/// <summary>
		/// �����ȡ�������
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="values"></param>
		/// <returns></returns>
		public static T GetRandValue<T>(params T[] values)
		{
			return values[Random.Range(0, values.Length)];
		}
	}

}
