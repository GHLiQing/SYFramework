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

			//SriptableState sriptableState = ScriptableObject.CreateInstance<SriptableState>(); //����SriptableState��Դ����
			//sriptableState.Name = "С�ڵ�����";

			//string path = "Assets/SriptableState.asset"; //·��

			//UnityEditor.AssetDatabase.CreateAsset(sriptableState, path); //�����õĶ��󱣴浽����·��
			//UnityEditor.AssetDatabase.SaveAssets();//������Դ
			//UnityEditor.AssetDatabase.Refresh();//ˢ��
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
