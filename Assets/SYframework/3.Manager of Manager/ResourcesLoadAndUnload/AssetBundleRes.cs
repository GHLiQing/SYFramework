using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.LQ.single
{
	public class AssetBundleRes : Res
	{
		public static AssetBundleManifest mainfestAssetBundle;

		//加载依赖使用 mainfest
		public static AssetBundleManifest Manifest
		{
			get
			{
				//加载manifest 用于加载依赖
				if (!mainfestAssetBundle)
				{
					var assetbundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/StreamingAssets");
					mainfestAssetBundle= assetbundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
				}
				
				return mainfestAssetBundle;
			}
		}

		/// <summary>
		/// 依赖加载异步支持
		/// </summary>
		/// <param name="onLoadDone"></param>
		private void LoadDependentBundleAsync(System.Action onLoadDone)
		{
			var dependBundles = Manifest.GetDirectDependencies(mPath.Substring(Application.streamingAssetsPath.Length + 1));

			if (dependBundles.Length==0)
			{
				onLoadDone();
			}
			var loadedCount = 0;

			foreach (var depenbundle in dependBundles)
			{
				var dependBundleFullPath = Application.streamingAssetsPath + "/" + depenbundle;
				loaderAsset.LoadAsync<AssetBundle>(dependBundleFullPath, bundle =>
				{
					loadedCount++;
					if (loadedCount==dependBundles.Length)
					{
						onLoadDone();
					}
				});

			}

		}
		
		private string mPath { get; set; }

		public AssetBundle MassetBundle
		{
			get { return Asset as AssetBundle; }
			private set { Asset = value; }
		}

		public AssetBundleRes(string path)
		{
			Debug.Log("传入的路劲:" + path);
			this.mPath = path;
			Name = path;
			State = ResState.Waiting;
		}
		//依赖
		private ResLoaderAsset loaderAsset = new ResLoaderAsset();
		/// <summary>
		/// 同步加载资源
		/// </summary>
		/// <returns></returns>
		public override bool LoadSync()
		{
			
			//	Debug.Log("截取的路径："+ mPath.Substring(Application.streamingAssetsPath.Length+1));
			//	Debug.Log("路径：" + mPath);
			//	Debug.Log("application path:"+Application.streamingAssetsPath);
			//获取查询到的依赖名
			var dependBundle = Manifest.GetDirectDependencies(mPath.Substring(Application.streamingAssetsPath.Length + 1));
			foreach (var depend in dependBundle)
			{
				//Debug.Log("depend:"+depend);
				//找到当前包的依赖包 资源名
				var dependBundleFunllPath = Application.streamingAssetsPath + "/" + depend;
				//加载依赖资源
				loaderAsset.LoadSync<AssetBundle>(dependBundleFunllPath);
			}

			Asset = AssetBundle.LoadFromFile(mPath);
			State = ResState.Loaded;


			return Asset;
		}
		/// <summary>
		/// 异步加载资源
		/// </summary>
		/// <param name="loadAbRes"></param>
		public override void LoadAsync()//System.Action<Res> loadAbRes
		{
			State = ResState.Loading;

			LoadDependentBundleAsync(() =>
			{
				var request = AssetBundle.LoadFromFileAsync(mPath);

				request.completed += operetion =>
				{

					Asset = request.assetBundle;
					State = ResState.Loaded;
				};

			});

			////加载ab 包里面的资源
			//var asset = AssetBundle.LoadFromFileAsync(mPath);

			//asset.completed += operation => {

			//	Asset = asset.assetBundle;

			//	State = ResState.Loaded;
			//	//	Debug.Log("AssetBundleRes 加载资源" + Asset);
			//	//loadAbRes.Invoke(this);
			//};

		}

		protected override void OnRelesasRes()
		{
			if (MassetBundle!=null)
			{
				MassetBundle.Unload(true);
				Asset = null;
				loaderAsset.ReleaseAll();
				loaderAsset = null;
			}
			ResMgr.Instance.SharedLoadedReses.Remove(this);
		}
		
	}

}
