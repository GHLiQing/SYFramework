using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.LQ.single
{
	/// <summary>
	/// 从AssetBundle 中加载资源
	/// </summary>
	public class AssetRes : Res
	{

		private string mOwnerBundleName;

		public AssetRes(string assetName,string assetBundleName)
		{
			Debug.Log("???????????????????????????????????????????????????");
			Name = assetName;
			mOwnerBundleName = assetBundleName;
		}

		public ResLoaderAsset mResLoader = new ResLoaderAsset();

		public override void LoadAsync()
		{

			mResLoader.LoadAsync<AssetBundle>(mOwnerBundleName, bundle => {

				var assetRequest = bundle.LoadAssetAsync(Name);

				assetRequest.completed += operation =>
				{

					Asset = assetRequest.asset;

					State = ResState.Loaded;
				};
			});
			
		}

		public override bool LoadSync()
		{
			var bundle = mResLoader.LoadSync<AssetBundle>(mOwnerBundleName);

			Asset = bundle.LoadAsset(Name);

			State = ResState.Loaded;
			return Asset;
		}

		protected override void OnRelesasRes()
		{
			if (Asset is GameObject)
			{

			}
			else
			{
				Resources.UnloadAsset(Asset);

				mResLoader = null;
				ResMgr.Instance.SharedLoadedReses.Remove(this);

			}
			
		}
	}
}

