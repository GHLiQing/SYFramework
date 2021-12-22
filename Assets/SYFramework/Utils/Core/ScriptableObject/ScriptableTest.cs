using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace SYFramework
{
	public class ScriptableTest : MonoBehaviour
	{
		//public Step current;

		
		private void Awake()
		{

			//SriptableState sriptableState = ScriptableObject.CreateInstance<SriptableState>(); //创建SriptableState资源对象
			//sriptableState.Name = "小黑的名字";

			//string path = "Assets/SriptableState.asset"; //路径

			//UnityEditor.AssetDatabase.CreateAsset(sriptableState, path); //创建好的对象保存到本地路径
			//UnityEditor.AssetDatabase.SaveAssets();//保存资源
			//UnityEditor.AssetDatabase.Refresh();//刷新
			//Debug.Log(sriptableState.Name);

		}

		private void Test1()
		{
			//Debug.Log("Step:" + current.Name);

			//Instantiate(AssetManager.GetInstance.Player);

			//foreach (var item in AssetManager.GetInstance.playerName)
			//{
			//	Debug.Log(item);
			//}
		}


	}
	public class Test{


		//[MenuItem("SYFramework/Step/TestStep")]
		//public static void CreatScirptable()
		//{
		//	Step step = ScriptableObject.CreateInstance<Step>();

		//	AssetDatabase.CreateAsset(step, "Assets/Step.asset");
		//	AssetDatabase.SaveAssets();
		//}
	}
	
	

}
