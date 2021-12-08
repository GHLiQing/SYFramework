using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework;
namespace Reskit
{
	/// <summary>
	///  ����ά��ȫ�ֵ���Դ�����
	/// </summary>
	public class ResMgr : MonoSingleton<ResMgr>
	{

		public List<Res> SharedLoadedRes = new List<Res>();
#if UNITY_EDITOR

		private void OnGUI()
		{
			
			if (Input.GetKey(KeyCode.F1))
			{
				GUILayout.BeginVertical();
				{
					SharedLoadedRes.ForEach(res =>{

						GUILayout.Label(string.Format("Name:{0},RefCount:{1}", res.Name, res.RefCount));
					});

					
				}
				GUILayout.EndVertical();
			}
		}
#endif

	}

}
