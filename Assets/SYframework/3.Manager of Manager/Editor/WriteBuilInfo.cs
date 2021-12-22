using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

namespace SYFramework.LQ
{
	/// <summary>
	/// webGL打包场景配置文件
	/// </summary>
	public class WriteBuilInfo 
	{

#if UNITY_EDITOR

		[MenuItem("webGL打包场景配置文件/打包配置/写打包场景文件")]

#endif
		private static void WriteAllScenesLevels()
		{
			if (UnityEditor.EditorBuildSettings.scenes.Length>0)
			{
				//dstring path1 = "C:/Users/MIDOU/Desktop/_Scripts&ScriptableObjects3.Manager of ManagerLevelManagerLevelManager/";
				List<string> Levels_Lists = new List<string>();
				for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
				{
					Debug.Log(EditorBuildSettings.scenes[i].path.ToString());
					Levels_Lists.Add(EditorBuildSettings.scenes[i].path.ToString());
				}
				Debug.Log("读取完成");
				File.WriteAllLines(Application.dataPath + "/Levels.txt",Levels_Lists, Encoding.Default);
				Debug.Log("写入成功");
			}
		}

#if UNITY_EDITOR
		[MenuItem("webGL打包场景配置文件/打包配置/写打包保存地址")]
#endif
		private static void WriteAllBuilOathLevels()
		{
			//选择文件位置
			//string path = EditorUtility.SaveFolderPanel("Choose Loaction of BuoltGame", "", "");

			string path1 = "C:/Users/MIDOU/Desktop";
			if (UnityEditor.EditorBuildSettings.scenes.Length > 0)
			{
				List<string> PathLevels = new List<string>();
				for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
				{
					Debug.Log(path1 + EditorBuildSettings.scenes[i].path.ToString().Replace("Assets","").Replace("/","").Replace(".unity",""));
					//创建文件路径（创建文件夹）
					Directory.CreateDirectory(path1 + EditorBuildSettings.scenes[i].path.ToString().Replace("Assets", "").Replace("/", "").Replace(".unity", ""));
					PathLevels.Add(path1 + EditorBuildSettings.scenes[i].path.ToString().Replace("Assets", "").Replace("/", "").Replace(".unity", ""));
				}
				Debug.Log("读取完成"+PathLevels.Count);
				//写入配置文件
				File.WriteAllLines(Application.dataPath + "/Pathlevels.txt", PathLevels, Encoding.Default);
				Debug.Log("写入完成");
			}
			else
			{
				Debug.Log("没有场景");
			}
		}
	}

}
