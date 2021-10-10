using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LQFramework
{
	public class ResLoader
	{

		private List<Object> mLoaderAsset = new List<Object>();

		public T Load<T>(string assetName) where T:Object
		{
			var asset = mLoaderAsset.Find(masset => masset.name == assetName);
			if (asset)
			{
				return asset as T;
			}

			asset = Resources.Load<T>(assetName);
			mLoaderAsset.Add(asset);
			return asset as T;
		}

		public void UnLoaderAsset()
		{
			mLoaderAsset.ForEach(asset => Resources.UnloadAsset(asset));

			mLoaderAsset.Clear();
		}
	}
}

