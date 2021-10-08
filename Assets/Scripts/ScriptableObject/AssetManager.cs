using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	[CreateAssetMenu(menuName ="Task/AssetManager")]
	public class AssetManager:ScriptableObject
	{
		#region 单例写法
		/// <summary>
		/// 单例写法
		/// </summary>
		private static AssetManager instance;

		public static AssetManager GetInstance
		{
			get
			{
				if (instance == null)
				{
					instance = Resources.Load<AssetManager>("AssetManager");
				}
				return instance;
			}

		}
		#endregion


		#region 方法
		///// <summary>
		///// 另外一种加载方式
		///// </summary>
		///// <returns></returns>
		//public static AssetManager GetVar()
		//{
		//	return Resources.Load<AssetManager>("AssetManager");
		//}
		#endregion


		public GameObject Player;

		public List<string> playerName = new List<string>();
		
	}

}
