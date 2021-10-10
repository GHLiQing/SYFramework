using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.LQ.single
{
	public class ResourcesRes : Res
	{

		//路径+资源名字
		private string mPath;

		public ResourcesRes(string path)
		{
			State = ResState.Waiting;
			//去掉前缀
			this.mPath = path.Substring("resources://".Length);
			//保存路径名字用来作为资源名
			Name = path;
		}

		/// <summary>
		/// 同步加载 api
		/// </summary>
		/// <returns></returns>
		public override bool LoadSync()
		{
			Asset = Resources.Load(mPath);
			State = ResState.Loaded;
			return Asset;
		}

		/// <summary>
		/// 异步加载api 回调资源
		/// </summary>
		/// <param name="onLoaded"></param>
		public override void LoadAsync()//System.Action<Res> onLoadedRes
		{
			State = ResState.Loading;
			//返回一个ResourcesRequest对象
			var request = Resources.LoadAsync(mPath);
			//资源得到之后完成回调
			request.completed += operation => {
				
				//res 里面 异步调用之后回调 资源异步加载完成之后 赋值给当前对象的asset
				Asset = request.asset;

				State = ResState.Loaded;
				// 回调
				//onLoadedRes.Invoke(this);
			};
		}
		protected override void OnRelesasRes()
		{

			if (Asset!=null)
			{
				//卸载prefab  游戏资源
				if (Asset is GameObject)
				{
					//Resources.UnloadUnusedAssets();
				}
				else
				{
					Resources.UnloadAsset(Asset);
				}
				Asset = null;
			}
			
			ResMgr.Instance.SharedLoadedReses.Remove(this);
			
		}
	}

}
