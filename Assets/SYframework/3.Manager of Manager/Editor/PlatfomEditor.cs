using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
namespace SYFramework.LQ
{
	public class PlatfomEditor
	{
		[UnityEditor.MenuItem("FrameworkDesign2021/1.复制值在粘贴板上")]
		private static void MenuClikced_1()
		{
			GUIUtility.systemCopyBuffer = "需要复制的文字" + DateTime.Now.ToString("yyyymmdd_hh");
		}

		[UnityEditor.MenuItem("FrameworkDesign2021/2.导出UnityPackage")]
		private static void MenuClikced_2()
		{
			var assetPathName = "Assets/QFramework";
			var fileName = "QFramework_" + DateTime.Now.ToString("YYYYMMDD_HH") + ".unityPackage"; ;
			AssetDatabase.ExportPackage(assetPathName,fileName,ExportPackageOptions.Recurse);
		}

		[UnityEditor.MenuItem("FrameworkDesign2021/3.打开所在文件夹")]
		private static void MenuClikced_3()
		{
			Application.OpenURL("file:///"+Application.dataPath);
		}

		[UnityEditor.MenuItem("FrameworkDesign2021/4 menuItem 复用")]
		private static void MenuClikced_4()
		{
			EditorApplication.ExecuteMenuItem("FrameworkDesign2021/2.导出UnityPackage");
			Application.OpenURL("file:///" +Path.Combine(Application.dataPath,"..//"));
		}


		public static string GenerateUnityPackageName()
		{
			return "QFramework_" + DateTime.Now.ToString("yyyyMMdd_hh");
		}

		public static void CopyText(string text)
		{
			GUIUtility.systemCopyBuffer = text;
		}

		public static void OpenInFolder(string folderPath)
		{
			Application.OpenURL("file:///" + folderPath);
		}

		public static void CallMenuItem(string menuPath)
		{
			EditorApplication.ExecuteMenuItem(menuPath);
		}

		public static void ExportPackage(string assetPathName, string fileName)
		{
			AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
		}

		[MenuItem("QFramework/8.总结之前的方法/1.获取文件名")]
		private static void MenuClicked()
		{
			Debug.Log(GenerateUnityPackageName());
		}

		[MenuItem("QFramework/8.总结之前的方法/2.复制文本到剪切板")]
		private static void MenuClicked2()
		{
			CopyText("要复制的关键字");
		}

		[MenuItem("QFramework/8.总结之前的方法/3.生成文件名到剪切板")]
		private static void MenuClicked3()
		{
			CopyText(GenerateUnityPackageName());
		}

		[MenuItem("QFramework/8.总结之前的方法/4.导出 UnityPackage")]
		private static void MenuClicked4()
		{
			ExportPackage("Assets/QFramework", GenerateUnityPackageName() + ".unitypackage");
		}

		[MenuItem("QFramework/8.总结之前的方法/5.打开所在文件夹")]
		private static void MenuClicked5()
		{
			OpenInFolder(Application.dataPath);
		}

		[MenuItem("QFramework/8.总结之前的方法/6.MenuItem 复用")]
		private static void MenuClicked6()
		{
			CallMenuItem("QFramework/8.总结之前的方法/4.导出 UnityPackage");
			OpenInFolder(Path.Combine(Application.dataPath, "../"));
		}

		[MenuItem("QFramework/8.总结之前的方法/7.自定义快捷键")]
		private static void MenuClicked7()
		{
			Debug.Log("%e 意思是快捷键 cmd/ctrl + e");
		}

	}

}

