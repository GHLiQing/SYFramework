using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// Resources 加载器
	/// </summary>
	public class ResourcesRes : Res
	{

		private string mPath;
		public ResourcesRes(string path)
		{
			Name = path;
			mPath = path.Substring("resources://".Length);
			State = ResState.Waiting;
		}

		/// <summary>
		/// 同步加载
		/// </summary>
		/// <returns></returns>
		public override bool LoadSync()
		{
			Asset = Resources.Load(mPath);
			State = ResState.Loaded;
			return Asset;
		}

		/// <summary>
		/// 异步加载
		/// </summary>
		/// <param name="onLoaded"></param>
		public override void LoadAsync()
		{
			State = ResState.Loading;

			ResourceRequest resourceRequest = Resources.LoadAsync(mPath);

			resourceRequest.completed += o =>
			{
				Asset = resourceRequest.asset;

				State = ResState.Loaded;
				
			};
		}


		public override void OnReleaseRes()
		{
			if (Asset!=null)
			{
				if (Asset is GameObject)
				{

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
