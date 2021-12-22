using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework;
namespace Reskit
{
	/// <summary>
	///  负责维护全局的资源缓存池
	/// </summary>
	public class ResMgr : MonoSingleton<ResMgr>
	{

		public List<Res> SharedLoadedReses = new List<Res>();
#if UNITY_EDITOR

		private void OnGUI()
		{
			
			if (Input.GetKey(KeyCode.F1))
			{
				GUILayout.BeginVertical();
				{
					SharedLoadedReses.ForEach(res =>{

						GUILayout.Label(string.Format("Name:{0},RefCount:{1},State:{2}", res.Name, res.RefCount,res.State));
					});

					
				}
				GUILayout.EndVertical();
			}
		}
#endif

	}

}
