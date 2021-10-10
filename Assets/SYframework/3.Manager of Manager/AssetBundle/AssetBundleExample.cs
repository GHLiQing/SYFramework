using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using QFramework.LQ.single;
using System.Linq;
namespace QFramework
{
	public class AssetBundleExample : MonoBehaviour
	{
#if UNITY_EDITOR

		[MenuItem("FrameworkDesign2021/Moudle/AssetBunle/Build AssetBundle",false,12)]
		private static void MenuOnClick()
		{
			
			if (!Directory.Exists(Application.streamingAssetsPath))
			{
				Directory.CreateDirectory(Application.streamingAssetsPath);
			}
			//打包 ab标记的资源
			UnityEditor.BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);

		}

		[MenuItem("FrameworkDesign2021/Moudle/AssetBunle/Run AssetBundle Example", false, 13)]
		private static void MenuOnClick_1()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject("AssetBundle Example").AddComponent<AssetBundleExample>();
		}

#endif

		ResLoaderAsset loaderAsset = null;

		AssetBundle assetBundle;

		AssetBundle streamingAb;
		private void Start()
		{
			//加载ab 资源
			//assetBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/cube_prefab");
			//var go= assetBundle.LoadAsset<GameObject>("Cube");
			//Instantiate(go);


			loaderAsset = new ResLoaderAsset();
			var goo = loaderAsset.LoadSync<GameObject>("resources://LoadCube");
			//var go = assetBundle.LoadAsset<GameObject>("Sphere"); //没有加载依赖包 导致材质丢失
			Instantiate(goo);

			//加载ab 配置表
			//streamingAb = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/StreamingAssets");

			//var mainfest = streamingAb.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
			//遍历AssetBundleManifest 表中的资源 进行输入资源名字
			//mainfest.GetAllAssetBundles()
			//	.ToList()
			//	.ForEach(_ => Debug.Log("ab包资源名： "+_));

			//遍历
			//mainfest.GetAllDependencies("sphere")
			//	.ToList()
			//	.ForEach(dependBundle => Debug.Log("依赖包资源名: "+dependBundle));


			

			
		}

		private void OnDestroy()
		{
			//assetBundle.Unload(true);
			assetBundle = null;
			loaderAsset.ReleaseAll();
			loaderAsset = null;
		}

		public class Player
		{

			public string name;
			public int id;

			public Player(string name,int id)
			{
				this.name = name;
				this.id = id;
			}

			
		}

		public class Tets
		{
			private void Te()
			{
				//List<Player> players = new List<Player>() {

				//	new Player("小红",1001),
				//	new Player("小白",1002),
				//	new Player("小s",1003),
				//	new Player("小e",1004)

				//};

				//players.Select(player => player.id==1002)
				//	.ToList()
				//	.ForEach(isplayer=> {

				//		if (isplayer)
				//		{
				//			Debug.Log("查询到");
				//		}
				//	});

				//var pl = players.Find(player => player.name == "小红");

				//Debug.Log(pl.name+"   "+pl.id);

				//Dictionary<string, string> dicPlayer = new Dictionary<string, string>() {
				//	{"1","1" },
				//		{"2","2" },
				//			{"3","3" },

				//};

			}
		}
	}
}

