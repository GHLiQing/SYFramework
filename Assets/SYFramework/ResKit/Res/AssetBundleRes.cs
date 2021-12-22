using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// AsetBundle 加载器
	/// </summary>
	public class AssetBundleRes : Res
	{
		public string mPath;

		public AssetBundleRes(string assetBundleName)
		{
			mPath = ResKitUtil.FullPathforAssetBundleName(assetBundleName);
			Name = assetBundleName;

			State = ResState.Waiting;
		}

		public AssetBundle AssetBundle
		{
			get { return Asset as AssetBundle; }
			private	set { Asset = value; }

		}
		#region 依赖处理

		private static AssetBundleManifest mManifest;

		public static AssetBundleManifest Manifest
		{
			get
			{
				if (!mManifest)
				{
					var bundle = AssetBundle.LoadFromFile(ResKitUtil.FullPathforAssetBundleName(ResKitUtil.GetPlatformName()));//Application.streamingAssetsPath + "/StreamingAssets"
					Debug.Log(ResKitUtil.FullPathforAssetBundleName(ResKitUtil.GetPlatformName()));
					mManifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

				}

				return mManifest;
			}
			
		}
		#endregion


		private ResLoader mResLoader = new ResLoader();

		/// <summary>
		/// 异步加载
		/// </summary>
		/// <param name="onLoaded"></param>
		public override void LoadAsync()
		{
			State = ResState.Loading;
			LoadDependBundleAsync(() => {

				var requ = AssetBundle.LoadFromFileAsync(mPath);
				requ.completed += obj => {

					Asset = requ.assetBundle;

					State = ResState.Loaded;

				};

			});
		}

		public override bool LoadSync()
		{
			

			var dependBundles = Manifest.GetDirectDependencies(mPath.Substring(Application.streamingAssetsPath.Length + 1));

			foreach (var dependBundle in dependBundles)
			{
				var dependBundleFullPath = Application.streamingAssetsPath + "/" + dependBundle;
				mResLoader.LoadSync<AssetBundle>(dependBundleFullPath);
			}

			Asset = AssetBundle.LoadFromFile(mPath);

			State = ResState.Loaded;

			return Asset;
		}

		private void LoadDependBundleAsync(Action onLoadDone)
		{
			var dependBundles = Manifest.GetDirectDependencies(mPath.Substring(Application.streamingAssetsPath.Length + 1));

			if (dependBundles.Length == 0)
			{
				onLoadDone();
			}

			var loadedCount = 0;

			foreach (var dependBundle in dependBundles)
			{
				var dependBundleFullPath = Application.streamingAssetsPath + "/" + dependBundle;
				mResLoader.LoadAsync<AssetBundle>(dependBundleFullPath, bundle =>
				{
					loadedCount++;

					if (loadedCount == dependBundles.Length)
					{
						onLoadDone();
					}
				});
			}
		}

		public override void OnReleaseRes()
		{
			if (AssetBundle!=null)
			{
				AssetBundle.Unload(true);
				AssetBundle = null;

				mResLoader.ReleaseAll();
				mResLoader = null;
			}
			ResMgr.Instance.SharedLoadedReses.Remove(this);
		}
	}

}
