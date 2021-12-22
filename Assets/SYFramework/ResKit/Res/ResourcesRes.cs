using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// Resources ������
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
		/// ͬ������
		/// </summary>
		/// <returns></returns>
		public override bool LoadSync()
		{
			Asset = Resources.Load(mPath);
			State = ResState.Loaded;
			return Asset;
		}

		/// <summary>
		/// �첽����
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
