using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework.LQ.single;
namespace SYFramework.LQ.single
{
	/// <summary>
	/// 维护安全的资源池
	/// 从资源加载类剥离出来
	/// 测试工具
	/// </summary>
	public class ResMgr : MonoSingleton<ResMgr>
	{
		/// <summary>
		/// 全局访问资源的接口
		/// </summary>
		public List<Res> SharedLoadedReses = new List<Res>();

		
#if UNITY_EDITOR
		private void OnGUI()
		{
			//通过ongui 渲染调用的资源多少次
			if (Input.GetKey(KeyCode.F1))
			{
				GUILayout.BeginVertical("box");
				SharedLoadedReses.ForEach(loadedRes => {

					GUILayout.Label(string.Format("name:{0},refcount:{1}，state:{2}", loadedRes.Name, loadedRes.RefCount,loadedRes.State)) ;

				});
				GUILayout.EndVertical();
			}
		}
#endif



	}
}

