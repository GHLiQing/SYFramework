using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// 管理已经加载的资源
	/// </summary>
	public class AssetRes : Res
	{
		private string mOwnerbundleName;

		public AssetRes(string assetName, string assetBundleName)
		{
			Name = assetName;

			mOwnerbundleName = assetBundleName;
		}

		private ResLoader mResLoader = new ResLoader();

		public override bool LoadSync()
		{
			var bundle = mResLoader.LoadSync<AssetBundle>(mOwnerbundleName);

			Asset = bundle.LoadAsset(Name);

			State = ResState.Loaded;

			return Asset;
		}

		public override void LoadAsync()
		{
			mResLoader.LoadAsync<AssetBundle>(mOwnerbundleName, bundle =>
			{
				var assetRequest = bundle.LoadAssetAsync(Name);

				assetRequest.completed += operation =>
				{
					Asset = assetRequest.asset;

					State = ResState.Loaded;
				};
			});
		}

		public override void OnReleaseRes()
		{
			if (Asset is GameObject)
			{

			}
			else
			{
				Resources.UnloadAsset(Asset);
				Asset = null;
			}

			mResLoader.ReleaseAll();
			mResLoader = null;

			ResMgr.Instance.SharedLoadedReses.Remove(this);
		}
	}


}
