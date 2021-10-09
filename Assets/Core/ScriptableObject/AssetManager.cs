using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	[CreateAssetMenu(menuName ="Task/AssetManager")]
	public class AssetManager:ScriptableObject
	{
		#region ����д��
		/// <summary>
		/// ����д��
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


		#region ����
		///// <summary>
		///// ����һ�ּ��ط�ʽ
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
