using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.LQ.single
{
	public class ResLoadAssetExample : MonoBehaviour
	{
		ResLoaderAsset loaderAsset;
		GameObject cube;
		private void Awake()
		{
			loaderAsset = new ResLoaderAsset();
			var clip= loaderAsset.LoadSync<AudioClip>("resources://bg");
			
			AudioManager.Instance.PlayMusic(clip,true);

			cube = loaderAsset.LoadSync<GameObject>("resources://LoadCube");
			Instantiate(cube);
		}

		private void OnDestroy()
		{
			cube = null;
			loaderAsset.ReleaseAll();
			
			loaderAsset = null;
		}
	}

}

