using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ.single
{
	public class LoadABAssetExample : MonoBehaviour
	{

		private ResLoaderAsset mResLoader = new ResLoaderAsset();

		private AssetBundle mBundle;
		private void Awake()
		{
			mResLoader.LoadAsync<GameObject>(Application.streamingAssetsPath + "/sphere_prefab", "Sphere", obj =>
			{

				Instantiate(obj);
			});
		}


		private void OnDestroy()
		{

			mResLoader.ReleaseAll();
			mResLoader = null;
			mBundle = null;
		}
	}

}
